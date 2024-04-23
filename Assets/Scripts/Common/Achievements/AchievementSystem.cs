using Patterns.Behaviour.EventQueue;
using Patterns.Behaviour.EventQueueObserver;
using UnityEngine;

namespace Common.Achievements
{
    public class AchievementSystem : IEventObserver
    {
        private int _numberOfDeaths = 0;

        public void ShowAchievement(AchievementEventData data)
        {
            Debug.Log($"New Achievement: {data?.EventInfo}");
            EventQueueObserver.Instance.Subscribe(EventIds.EnemyDeaths, this);
        }

        public void Process(EventData eventData)
        {
            _numberOfDeaths += 1;
            if (_numberOfDeaths >= 3)
            {
                AchievementEventData newEventData = new AchievementEventData($"Triple Kill");
                EventQueueObserver.Instance.EnqueueEvent(newEventData);
                _numberOfDeaths = 0;
            }
        }
    }
}