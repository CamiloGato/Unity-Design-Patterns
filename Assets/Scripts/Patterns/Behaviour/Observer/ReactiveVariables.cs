using System;
using UnityEngine;

namespace Patterns.Behaviour.Observer
{
    [CreateAssetMenu(menuName = "Variables/Reactive", fileName = "ReactiveVariables")]
    public class ReactiveVariables : ScriptableObject
    {
        public Action<int> HealthNotify { get; set; }
        public Action<int> ScoreNotify { get; set; }
        
        private int _health;
        private int _score;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                HealthNotify?.Invoke(_health);
            }
        }
        
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                ScoreNotify?.Invoke(_score);
            }
        }
    }
}