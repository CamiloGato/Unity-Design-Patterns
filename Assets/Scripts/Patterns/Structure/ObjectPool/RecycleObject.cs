using UnityEngine;

namespace Patterns.Structure.ObjectPool
{
    public abstract class RecycleObject : MonoBehaviour
    {
        private ObjectPool _objectPool;

        public void Configure(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public void Recycle()
        {
            _objectPool.RecycleGameObject(this);
        }
        
        public abstract void Init();
        public abstract void Release();
    }
}