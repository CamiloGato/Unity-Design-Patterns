using UnityEngine;

namespace Common.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SingleEnemy : Enemy
    {
        public float speed;
        private Rigidbody2D _rigidBody2D;

        protected void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        public override void Move(Vector2 direction)
        {
            Vector2 velocity = direction * speed;
            _rigidBody2D.velocity = velocity;
        }
    }
}