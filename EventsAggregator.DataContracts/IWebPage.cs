using System;

namespace EventsAggregator.DataContracts
{
    public interface IWebPage
    {
        int Id { get; }
        string Description { get; }
        Uri Uri { get; }
    }
}