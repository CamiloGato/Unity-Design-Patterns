using System;
using System.Collections.Generic;
using Common.Achievements;
using UnityEngine;

namespace Patterns.Behaviour.EventQueue
{
    public class EventQueue : MonoBehaviour
    {
        public static EventQueue Instance { get; set; }

        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;

        private void Awake()
        {
            Instance = this;

            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
        }

        public void EnqueueEvent(EventData eventData)
        {
            _nextEvents.Enqueue(eventData);
            Debug.Log($"Enqueued event {eventData.EventId} on frame {Time.frameCount}");
        }

        private void LateUpdate()
        {
            ProcessEvent();
        }

        private void ProcessEvent()
        {
            (_currentEvents, _nextEvents) = (_nextEvents, _currentEvents);

            foreach (EventData currentEvent in _currentEvents)
            {
                ProcessEvent(currentEvent);
            }
            
            _currentEvents.Clear();
        }

        private static void ProcessEvent(EventData eventData)
        {
            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");
            switch (eventData.EventId)
            {
                case EventIds.EnemyDeaths:
                    // EnemyDeathsCounter.Instance.ShowAchievementDeaths(eventData as DeathsEventData);
                    break;
                case EventIds.AchievementUnlocked:
                    // AchievementsManager.Instance.ShowAchievement(eventData as AchievementEventData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}