using System;
using Patterns.Structure.Adapter;
using UnityEngine;

namespace Common.Playable
{
    public class Player : MonoBehaviour
    {
        private IInput _input;
        private Car _car;

        public void SetComponents(IInput input, Car car)
        {
            _input = input;
            _car = car;
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.right * _input.Horizontal();
        }
    }
}