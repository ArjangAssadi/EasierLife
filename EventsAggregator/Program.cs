using System;
using System.Collections.Generic;
using EventsAggregator.Builders;
using EventsAggregator.Entities.BO;
using EventsAggregator.Parts.Extractors;
using EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces;
using EventsAggregator.Providers;
using EventsAggregator.Providers.WebPage;

namespace EventsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            WebPageProvider webPageProvider = new WebPageProvider();
            IEnumerable<IWebPage> webPages = webPageProvider.All();

            Builders.WebPageToTextTableExtractorBuilder wb = new WebPageToTextTableExtractorBuilder();


            IList<IWebPageToTextTableExtractor> extractorList = new List<IWebPageToTextTableExtractor>();

            foreach (var webPage in webPages)
            {
                extractorList.Add(wb.Build(webPage));
            }


            foreach (IWebPageToTextTableExtractor extractor in extractorList)
            {
                extractor.ProcessingDataContainer.TextTable
            }

            EventsExtractorEvents ce = new EventsExtractorEvents();
            ce.TextTableToEventsConvertor = plugin;
            
            ce.ExtractEvents();
            
        }
    }
}
