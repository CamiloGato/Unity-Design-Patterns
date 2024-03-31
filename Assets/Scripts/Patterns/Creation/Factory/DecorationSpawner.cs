using Common.Configuration;

namespace Patterns.Creation.Factory
{
    public class DecorationSpawner
    {
        private readonly DecorationFactory _decorationFactory;

        public DecorationSpawner(DecorationFactory decorationFactory)
        {
            _decorationFactory = decorationFactory;
        }

        public void SpawnDecoration(Id id)
        {
            _decorationFactory.Create(id);
        }
        
    }
}