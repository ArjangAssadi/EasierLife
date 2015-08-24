using System;
using EventsAggregator.DataContracts;

namespace EventsAggregator.DataObjects
{
    public class CanberraEvent : IEvent
    {
        public DateTime DateTime { get; set; }
        public string Heading { get; set; }
        public string Details { get; set; }
        public Uri InfoLink { get; set; }
    }
}