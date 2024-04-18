using Common.Configuration;
using Patterns.Structure.ObjectPool;
using UnityEngine;

namespace Common.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : RecycleObject
    {
        public Id id;
        
        private Rigidbody2D _rigidBody2D;
        private Transform _transform;
        private Vector2 _initPosition;
        
        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
        }

        private void Update()
        {
            if (Vector2.Distance(_initPosition, _transform.position) > 3f)
                Recycle();
        }
        
        public override void Init()
        {
            _rigidBody2D.velocity = _transform.right;
        }

        public override void Release() {}
    }
}