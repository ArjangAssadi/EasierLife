using EventsAggregator.DataContracts;
using HtmlAgilityPack;

namespace EventsAggregator.CodeObjects.ConversionLogic
{
    class GenericConversionLogicsForAllWebPage
    {
        public HtmlDocument Convert(IWebPage webPage)
        {
            var getHtmlWeb = new HtmlWeb();
            return getHtmlWeb.Load(webPage.Uri.OriginalString);
        }
    }
}