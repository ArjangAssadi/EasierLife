using EventsAggregator.DataContracts;
using EventsAggregator.DataObjects;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces
{
    internal interface IProcessingLogicContainer 
    {
        IProcessDataContainer ProcessDataContainer { get; set; }
        void Start();
        HtmlDocument Convert(IWebPage webPage);
        //TextTable Convert(HtmlDocument document); The logic for this will come from the page!
    }

}