using Common.Configuration;
using UnityEngine;

namespace Common.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public Id id;
        
        public abstract void Move(Vector2 position);
    }
}