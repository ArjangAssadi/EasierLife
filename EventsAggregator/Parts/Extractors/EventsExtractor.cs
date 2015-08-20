using System.Collections.Generic;
using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;
using EventsAggregator.Parts.ExtractorPlugins;

namespace EventsAggregator.Parts.Extractors
{
    internal class EventsExtractorEvents : ExtractorEvents
    {
        public EventsExtractorEvents() { }

        private IEnumerable<IEvent> _events;
        public IEnumerable<IEvent> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                CanHandleEvents.EventesLoaded(_events);
            }
        }

        public ITextTableToEventsConvertor TextTableToEventsConvertor
        {
            get { return _textTableToEventsConvertor; }
            set
            {
                _textTableToEventsConvertor = value;
                base.WebPageToTextTableExtractor = _textTableToEventsConvertor;
            }
        }

        private ITextTableToEventsConvertor _textTableToEventsConvertor;
        public void ExtractEvents()
        {
            Document = GetPage(WebPage);

            TextTable = _textTableToEventsConvertor.Convert(Document);

            Events = GetEvents(TextTable);
        }

        public IEnumerable<IEvent> GetEvents(TextTable textTable)
        {
            return new List<IEvent>();
        }

    }
}