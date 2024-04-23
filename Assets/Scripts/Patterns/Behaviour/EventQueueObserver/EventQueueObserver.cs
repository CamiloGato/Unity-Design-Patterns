using System.Collections.Generic;
using Patterns.Behaviour.EventQueue;
using UnityEngine;

namespace Patterns.Behaviour.EventQueueObserver
{
    public class EventQueueObserver : MonoBehaviour
    {
        public static EventQueueObserver Instance { get; set; }

        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;
        private Dictionary<EventIds, List<IEventObserver>> _observers;
        
        private void Awake()
        {
            Instance = this;
            
            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
            _observers = new Dictionary<EventIds, List<IEventObserver>>();
        }

        public void Subscribe(EventIds eventId, IEventObserver eventObserver)
        {
            if (!_observers.TryGetValue(eventId, out List<IEventObserver> eventObservers))
            {
                eventObservers = new List<IEventObserver>();
            }
            
            eventObservers.Add(eventObserver);
            _observers[eventId] = eventObservers;
        }

        public void UnSubscribe(EventIds eventIds, IEventObserver eventObserver)
        {
            _observers[eventIds].Remove(eventObserver);
        }

        public void EnqueueEvent(EventData eventData)
        {
            _nextEvents.Enqueue(eventData);
            Debug.Log($"Enqueued event {eventData.EventId} on frame {Time.frameCount}");
        }

        private void LateUpdate()
        {
            ProcessEvents();
        }

        private void ProcessEvents()
        {
            (_currentEvents, _nextEvents) = (_nextEvents, _currentEvents);

            foreach (EventData currentEvent in _currentEvents)
            {
                ProcessEvents(currentEvent);
            }
            
            _currentEvents.Clear();
        }

        private void ProcessEvents(EventData eventData)
        {
            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");
            if (_observers.TryGetValue(eventData.EventId, out List<IEventObserver> eventObservers))
            {
                foreach (IEventObserver eventObserver in eventObservers)
                {
                    eventObserver.Process(eventData);
                }
            }
        }
    }
}