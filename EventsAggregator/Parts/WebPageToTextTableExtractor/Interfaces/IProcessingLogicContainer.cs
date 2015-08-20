using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces
{
    internal interface IProcessingLogicContainer 
    {
        IProcessDataContainer ProcessDataContainer { get; set; }
        void Start();
        HtmlDocument Convert(IWebPage webPage);
        TextTable Convert(HtmlDocument document);
    }

}