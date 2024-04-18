using UnityEngine;

namespace Patterns.Behaviour.Strategy
{
    public interface IAttack
    {
        void Attack(Vector2 direction);
    }
}