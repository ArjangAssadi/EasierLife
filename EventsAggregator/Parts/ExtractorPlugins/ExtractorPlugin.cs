using System.Collections.Generic;
using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.ExtractorPlugins
{
    class CanHandleEvents : ICanHandleEvents
    {
        public void DocumentLoaded(HtmlDocument document)
        {
            throw new System.NotImplementedException();
        }

        public void TextTableLoaded(TextTable textTable)
        {
            throw new System.NotImplementedException();
        }

        public void EventesLoaded(IEnumerable<IEvent> events)
        {
            throw new System.NotImplementedException();
        }

        public void WebPageLoaded(IWebPage webPage)
        {
            throw new System.NotImplementedException();
        }
    }
}