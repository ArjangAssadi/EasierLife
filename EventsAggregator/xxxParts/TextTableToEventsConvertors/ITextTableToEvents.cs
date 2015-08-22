using System.Collections.Generic;
using EventsAggregator.DataContracts;
using EventsAggregator.DataObjects;
using EventsAggregator.StructuralObjects;

namespace EventsAggregator.Parts
{
    interface ITextTableToEventsConvertor
    {
        void TextTableLoaded(TextTable textTable);
        void EventesLoaded(IEnumerable<IEvent> events);
    }
}