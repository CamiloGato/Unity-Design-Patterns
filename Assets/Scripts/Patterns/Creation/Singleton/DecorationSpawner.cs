using System;
using System.Threading;
using Common.Configuration;
using Cysharp.Threading.Tasks;
using Patterns.Creation.Factory;

namespace Patterns.Creation.Singleton
{
    public class DecorationSpawner
    {
        private static DecorationSpawner _instance;
        public static DecorationSpawner Instance
        {
            get { return _instance ??= new DecorationSpawner(); }
        }
        
        private DecorationFactory _decorationFactory;
        private float _time;
        private Id _id;
        private UniTask _spawnTask;
        private CancellationTokenSource _cancellationTokenSource;

        private DecorationSpawner() {}
        
        public void SetUpDecorationFactory(DecorationFactory decorationFactory, float time, Id id)
        {
            _id = id;
            _decorationFactory = decorationFactory;
            _time = time;
        }

        public void ChangeDecorationId(Id id)
        {
            _id = id; 
        }

        public void StartSpawn()
        {
            if (!_id || _spawnTask.Status == UniTaskStatus.Pending) return;
            
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            _spawnTask = Spawn(_cancellationTokenSource.Token);
        }

        public void StopSpawn()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async UniTask Spawn(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _decorationFactory.Create(_id);
                await UniTask.Delay(TimeSpan.FromSeconds(_time), cancellationToken: cancellationToken);
            }
        }
        
    }
}