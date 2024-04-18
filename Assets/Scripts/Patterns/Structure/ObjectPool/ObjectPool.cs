using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Structure.ObjectPool
{
    public class ObjectPool
    {
        private readonly RecycleObject _prefab;
        private readonly HashSet<RecycleObject> _instantiateObject;
        private Queue<RecycleObject> _recycleObjects;
        private Transform _poolSpace;
        
        public ObjectPool( RecycleObject prefab )
        {
            _prefab = prefab;
            _instantiateObject = new HashSet<RecycleObject>();
        }

        public void Init(int numberOfInitialObjects, Transform poolSpace = null)
        {
            _recycleObjects = new Queue<RecycleObject>(numberOfInitialObjects);
            _poolSpace = poolSpace;
            
            for (int i = 0; i < numberOfInitialObjects; i++)
            {
                RecycleObject instance = InstantiateNewInstance();
                instance.gameObject.SetActive(false);
                _recycleObjects.Enqueue(instance);
            }
        }

        public T Spawn<T>()
        {
            RecycleObject recycleObject = GetInstance();
            _instantiateObject.Add(recycleObject);
            recycleObject.gameObject.SetActive(true);
            recycleObject.Init();
            return recycleObject.GetComponent<T>();
        }

        private RecycleObject InstantiateNewInstance()
        {
            RecycleObject instance = Object.Instantiate(_prefab, _poolSpace, true);
            instance.Configure(this);
            return instance;
        }

        private RecycleObject GetInstance()
        {
            if (_recycleObjects.Count > 0)
            {
                return _recycleObjects.Dequeue();
            }

            Debug.LogWarning($"Not enough recycled objects for {_prefab.name}");
            RecycleObject instance = InstantiateNewInstance();
            return instance;
        }

        public void RecycleGameObject(RecycleObject gameObjectToRecycle)
        {
            bool wasInstantiated = _instantiateObject.Remove(gameObjectToRecycle);
            if (!wasInstantiated)
                Debug.LogWarning($"{gameObjectToRecycle.name} was not instantiated");
            
            _recycleObjects.Enqueue(gameObjectToRecycle);
            
            gameObjectToRecycle.gameObject.SetActive(false);
            gameObjectToRecycle.Release();
        }
        
    }
}