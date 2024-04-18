using Patterns.Behaviour.Mediator;
using Patterns.Behaviour.Observer;
using Patterns.Behaviour.Strategy;
using Patterns.Structure.Adapter;
using UnityEngine;

namespace Common.Playable
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private IInput _input;
        private IAttack _attack;
        private CarMediator _carMediator;
        private Camera _mainCamera;
        private Rigidbody2D _rigidBody2D;
        private ReactiveVariables _variables;

        public void SetComponents(IInput input, IAttack attack, CarMediator carMediator, ReactiveVariables variables)
        {
            _input = input;
            _attack = attack;
            _carMediator = carMediator;
            _variables = variables;
            _mainCamera = Camera.main;
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_input.Fire())
            {
                Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - (Vector2) transform.position;
                direction.Normalize();
                _attack.Attack(direction);
                _variables.Score += 2;
            }

            if (_input.Brake())
            {
                _carMediator.Brake();
                _rigidBody2D.velocity = Vector2.zero;
                _variables.Health -= 4;
            }

            float horizontal = _input.Horizontal();
            if (horizontal != 0)
            {
                _rigidBody2D.AddForce(Vector2.right * horizontal, ForceMode2D.Force);
                _carMediator.Move();
            }
        }
    }
}