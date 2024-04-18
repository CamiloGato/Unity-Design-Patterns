using Patterns.Behaviour.Strategy;
using Patterns.Structure.Adapter;
using UnityEngine;

namespace Common.Playable
{
    public class Player : MonoBehaviour
    {
        private IInput _input;
        private IAttack _attack;
        private Car _car;
        private Camera _mainCamera;

        public void SetComponents(IInput input, IAttack attack, Car car)
        {
            _input = input;
            _attack = attack;
            _car = car;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_input.Fire())
            {
                Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - (Vector2) transform.position;
                direction.Normalize();
                _attack.Attack(direction);
            }
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.right * _input.Horizontal();
        }
    }
}