using Common.Configuration;

namespace Common.Enemies
{
    public class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;

        public EnemySpawner(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public Enemy Spawn(Id id)
        {
            return _enemyFactory.Create(id);
        }
    }
}