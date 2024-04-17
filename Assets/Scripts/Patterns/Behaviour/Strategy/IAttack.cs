using UnityEngine;

namespace Patterns.Behaviour.Strategy
{
    public interface IAttack
    {
        void Attack(Vector2 direction);
    }

    public class AttackSimple : IAttack
    {
        private Transform _origin;
        private GameObject _damageArea;
        private float _radius;

        public void Attack(Vector2 direction)
        {
            Vector2 position = (Vector2) _origin.position + direction * _radius;
        }
    }
}