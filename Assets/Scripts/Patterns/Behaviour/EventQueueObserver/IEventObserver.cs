using Patterns.Behaviour.EventQueue;

namespace Patterns.Behaviour.EventQueueObserver
{
    public interface IEventObserver
    {
        void Process(EventData eventData);
    }
}