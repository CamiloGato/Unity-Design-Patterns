using Common.Configuration;
using Common.Weapons;
using UnityEngine;

namespace Patterns.Behaviour.Strategy
{
    public class AttackBullet : IAttack
    {
        private readonly Transform _origin;
        private readonly BulletFactory _bulletFactory;
        private readonly Id _bulletId;
        private readonly float _radius;

        public AttackBullet(Transform origin, BulletFactory bulletFactory, Id bulletId, float radius)
        {
            _origin = origin;
            _bulletFactory = bulletFactory;
            _bulletId = bulletId;
            _radius = radius;
        }


        public void Attack(Vector2 direction)
        {
            Vector2 position = (Vector2) _origin.position + direction * _radius;
            Bullet bullet = _bulletFactory.Create(_bulletId);
            Quaternion rotation = Quaternion.FromToRotation(Vector2.right, direction);
            bullet.gameObject.transform.SetPositionAndRotation(position, rotation);
            bullet.Init();
        }
    }
}