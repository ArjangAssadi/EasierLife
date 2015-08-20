using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces
{
    internal interface IDataChangedNotifiable
    {
        void ProcessStarted();
        void WebPageIsSet(IWebPage webPage);
        void DocumentIsSet(HtmlDocument document);
        void TextTableIsSet(TextTable table);
    }
}