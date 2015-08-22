using System;

namespace EventsAggregator.DataContracts
{
    internal interface IWebPage
    {
        int Id { get; }
        string Description { get; }
        Uri Uri { get; }
    }
}