using System;
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

        public void SetComponents(IInput input, IAttack attack, Car car)
        {
            _input = input;
            _attack = attack;
            _car = car;
        }

        private void Update()
        {
            if (_input.Fire())
            {
                
            }
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.right * _input.Horizontal();
        }
    }
}