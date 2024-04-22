using Common.Achievements;
using Common.Configuration;
using Patterns.Structure.ObjectPool;
using UnityEngine;

namespace Common.Decorations
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Decoration : RecycleObject
    {
        public Id id;
        public Vector2 direction;
        
        private Rigidbody2D _rigidBody2D;
        private Transform _transform;
        private Vector2 _initPosition;
        
        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
            _initPosition = _transform.position;
        }
        
        public override void Init()
        {
            _transform.SetPositionAndRotation(_initPosition, Quaternion.identity);
            _rigidBody2D.velocity = direction;
        }
        
        private void Update()
        {
            if (Vector2.Distance(_initPosition, _transform.position) > 7f)
                Recycle();
        }

        public void Die()
        {
            EnemyDeathsCounter.Instance.AddDeath();
        }
        
        public override void Release()
        {
            
        }
    }
}