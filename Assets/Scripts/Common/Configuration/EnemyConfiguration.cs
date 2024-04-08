using System.Collections.Generic;
using Common.Enemies;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/EnemyConfiguration", fileName = "EnemyConfiguration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] private List<Enemy> enemies = new List<Enemy>();

        public Enemy GetEnemy(Id id)
        {
            return enemies.Find( (enemy) => enemy.id == id );
        }

    }
}