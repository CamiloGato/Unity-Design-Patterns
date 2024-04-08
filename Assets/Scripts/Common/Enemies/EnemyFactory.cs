using Common.Configuration;

namespace Common.Enemies
{
    public class EnemyFactory
    {
        private readonly EnemyConfiguration _enemyConfiguration;

        public EnemyFactory(EnemyConfiguration enemyConfiguration)
        {
            _enemyConfiguration = enemyConfiguration;
        }

        public Enemy Create(Id id)
        {
            return UnityEngine.Object.Instantiate(_enemyConfiguration.GetEnemy(id));
        }
    }
}