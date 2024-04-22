using Patterns.Behaviour.EventQueue;
using UnityEngine;

namespace Common.Achievements
{
    public class EnemyDeathsCounter : MonoBehaviour
    {
        public static EnemyDeathsCounter Instance { get; set; }
        
        private int _deaths;
        
        private void Awake()
        {
            Instance = this;
            _deaths = 0;
        }
        
        public void AddDeath()
        {
            _deaths += 1;
            if (_deaths >= 2)
            {
                AchievementEventData eventData = new AchievementEventData("Major death!");
                EventQueue.Instance.EnqueueEvent(eventData);
            }
        }

        public void ShowAchievementDeaths(EnemyDeathsEventData data)
        {
            Debug.Log($"Unlock Total Deaths: {data?.AmountDeaths}");
        }
    }
}