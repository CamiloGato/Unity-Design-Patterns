using System.Collections.Generic;
using Common.Enemies;
using UnityEngine;

namespace Patterns.Structure.Composite
{
    public class HordeEnemyComposite : Enemy
    {
        [SerializeField] private List<Enemy> enemies = new List<Enemy>();

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }
        
        public override void Move(Vector2 position)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move(position);
            }
        }
    }
}