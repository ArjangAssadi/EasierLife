using System.Collections.Generic;
using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;

namespace EventsAggregator.Parts
{
    interface ITextTableToEventsConvertor
    {
        void TextTableLoaded(TextTable textTable);
        void EventesLoaded(IEnumerable<IEvent> events);
    }
}