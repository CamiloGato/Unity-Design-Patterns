using Common.Configuration;
using Patterns.Creation.Factory;
using UnityEngine;

namespace Common
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private DecorationConfiguration decorationConfiguration;
        [SerializeField] private Id decorationToSpawnId;
        
        private DecorationSpawner _decorationSpawner;
        
        private void Awake()
        {
            DecorationFactory decorationFactory = new DecorationFactory(decorationConfiguration);
            _decorationSpawner = new DecorationSpawner(decorationFactory);
        }

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 3f, 3f);
        }

        public void Spawn()
        {
            _decorationSpawner.SpawnDecoration(decorationToSpawnId);
        }
        
    }
}