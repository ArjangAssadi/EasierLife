using System;

namespace EventsAggregator.Entities.BO.Events
{
    public class Event : IEvent
    {
        public DateTime DateTime { get; set; }
        public string Heading { get; set; }
        public string Details { get; set; }
        public Uri InfoLink { get; set; }
    }
}