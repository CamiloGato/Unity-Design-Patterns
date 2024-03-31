using Common.Configuration;
using UnityEngine;

namespace Common.Decorations
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Decoration : MonoBehaviour
    {
        public Id id;

        private Rigidbody2D _rigidBody2D;
        
        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidBody2D.velocity = new Vector2(1, 0);
        }
    }
}