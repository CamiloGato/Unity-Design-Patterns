using Common.Configuration;
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

        private DecorationSpawner() {}
        
        public void SetUpDecorationFactory(DecorationFactory decorationFactory)
        {
            _decorationFactory = decorationFactory;
        }

        public void SpawnDecoration(Id id)
        {
            _decorationFactory.Create(id);
        }
        
    }
}