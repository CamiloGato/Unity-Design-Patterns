using System.Collections.Generic;
using Common.Weapons;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/BulletConfiguration", fileName = "BulletConfiguration")]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField] private List<Bullet> decorations = new List<Bullet>();
        public List<Bullet> Bullets => decorations;
        
        public Bullet GetBullet(Id id)
        {
            return decorations.Find( (bullet) => bullet.id == id );
        }

    }
}