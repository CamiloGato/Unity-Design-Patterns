using UnityEngine;

namespace Common.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidBody2D;

        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        public void Shoot(Vector2 direction)
        {
            _rigidBody2D.velocity = direction;
        }
    }
}