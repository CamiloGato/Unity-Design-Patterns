using Common.Decorations;
using UnityEngine;

namespace Patterns.Behaviour.Strategy
{
    public class AttackSimple : IAttack
    {
        private readonly Transform _origin;
        private readonly float _radius;

        public AttackSimple(Transform origin, float radius)
        {
            _origin = origin;
            _radius = radius;
        }

        public void Attack(Vector2 direction)
        {
            Vector2 position = (Vector2) _origin.position + direction * _radius;
            float angle = Vector2.Angle(Vector2.right, position);
            Collider2D[] results = new Collider2D[5];
            Physics2D.OverlapBoxNonAlloc
            (
                position,
                new Vector2(1, 1),
                angle,
                results
            );
            
            foreach (Collider2D result in results)
            {
                if (!result) continue;
                
                if (result.TryGetComponent(out Decoration decoration))
                {
                    decoration.Recycle();
                }
            }
        }
    }
}