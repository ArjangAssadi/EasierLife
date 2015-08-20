using System.Collections.Generic;
using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;
using EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor.PageSpecificProcessingLogic
{
    class CanberraEventsPageProcessingLogic : IProcessingLogicContainer
    {
        public IProcessDataContainer ProcessDataContainer { get; set; }

        public void Start()
        {
            ProcessDataContainer.Document = Convert(ProcessDataContainer.WebPage);
        }

        public HtmlDocument Convert(IWebPage webPage)
        {
            var getHtmlWeb = new HtmlWeb();
            return getHtmlWeb.Load(webPage.Uri.OriginalString);
        }

        
    }
}