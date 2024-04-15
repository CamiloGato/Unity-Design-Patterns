using System;
using System.Collections.Generic;
using Common.Configuration;
using Common.Decorations;
using Patterns.Structure.ObjectPool;
using UnityEngine;

namespace Patterns.Creation.Factory
{
    public class DecorationFactory
    {
        private readonly Dictionary<Id, ObjectPool> _pools;
        
        public DecorationFactory(DecorationConfiguration decorationConfiguration, Transform position)
        {
            _pools = new Dictionary<Id, ObjectPool>();
            foreach (Decoration prefab in decorationConfiguration.Decorations)
            {
                ObjectPool pool = new ObjectPool(prefab);
                pool.Init(5, position);
                _pools.Add(prefab.id, pool);
            }
        }
        
        public Decoration Create(Id id)
        {
            if (!_pools.TryGetValue(id, out ObjectPool pool))
                throw new Exception("No Pool Implemented");
            Decoration decoration = pool.Spawn<Decoration>();
            
            return decoration;
        }
        
    }
}