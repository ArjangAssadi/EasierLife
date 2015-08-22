using System;

namespace EventsAggregator.DataContracts
{
    public interface IEvent
    {
        DateTime DateTime { get; set; }
        String Heading { get; set; }
        string Details { get; set; }
        Uri InfoLink { get; set; }
    }
}