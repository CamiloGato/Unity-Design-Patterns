using System;
using System.Collections.Generic;
using Common.Configuration;
using Patterns.Structure.ObjectPool;
using UnityEngine;

namespace Common.Weapons
{
    public class BulletFactory
    {
        private readonly Dictionary<Id, ObjectPool> _pools;

        public BulletFactory(BulletConfiguration bulletConfiguration, Transform position)
        {
            _pools = new Dictionary<Id, ObjectPool>();
            
            foreach (Bullet prefab in bulletConfiguration.Bullets)
            {
                ObjectPool pool = new ObjectPool(prefab);
                pool.Init(5, position);
                _pools.Add(prefab.id, pool);
            }
        }

        public Bullet Create(Id id)
        {
            if (!_pools.TryGetValue(id, out ObjectPool pool))
                throw new Exception("No Pool Implemented");
            Bullet decoration = pool.Spawn<Bullet>();
            
            return decoration;
        }
    }
}