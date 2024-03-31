using Common.Configuration;
using UnityEngine;

namespace Common.Decorations
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Decoration : MonoBehaviour
    {
        public Id id;
        public Vector2 direction;
        
        private Rigidbody2D _rigidBody2D;
        
        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidBody2D.velocity = direction;
        }
    }
}