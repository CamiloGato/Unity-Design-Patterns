namespace Patterns.Behaviour.EventQueue
{

    public enum EventIds
    {
        EnemyDeaths,
        AchievementUnlocked,
    }
    
    public abstract class EventData
    {
        public readonly EventIds EventId;

        protected EventData(EventIds eventId)
        {
            EventId = eventId;
        }
    }

    public class DeathsEventData : EventData
    {
        public readonly int AmountDeaths;
        
        public DeathsEventData(int amountDeaths) : base(EventIds.EnemyDeaths)
        {
            AmountDeaths = amountDeaths;
        }
    }
    
    public class AchievementEventData : EventData
    {
        public string EventInfo;
        
        public AchievementEventData(string eventInfo) : base(EventIds.AchievementUnlocked)
        {
            EventInfo = eventInfo;
        }
    }
}