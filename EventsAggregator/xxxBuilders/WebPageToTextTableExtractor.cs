using EventsAggregator.DataContracts;
using EventsAggregator.Parts.WebPageToTextTableExtractor;
using EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces;
using EventsAggregator.Parts.WebPageToTextTableExtractor.PageSpecificProcessingLogic;

namespace EventsAggregator.Builders
{
    class WebPageToTextTableExtractorBuilder
    {
        public IWebPageToTextTableExtractor Build(IWebPage webPage)
        {
            IWebPageToTextTableExtractor result = new WebPageToTextTableExtractor();

            result.ProcessingDataContainer = new ProcessDataContainer();
            result.ProcessingLogicContainer = new CanberraEventsPageProcessingLogic();
            result.ProcessingDataContainer.WebPage = webPage;
            
            return result;
        }
    }
}
