using Patterns.Behaviour.EventQueue;
using UnityEngine;

namespace Common.Achievements
{
    public class AchievementsManager : MonoBehaviour
    {
        public static AchievementsManager Instance { get; set; }
        
        private void Awake()
        {
            Instance = this;
        }

        public void ShowAchievement(AchievementEventData data)
        {
            Debug.Log($"New Achievement: {data?.EventInfo}");
        }
        
    }
}