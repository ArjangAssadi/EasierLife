using System.Collections.Generic;
using EventsAggregator.CodeContracts;
using EventsAggregator.CodeObjects.Engines;
using EventsAggregator.DataContracts;
using EventsAggregator.Providers.ConversionLogics;

using EventsAggregator.Providers.WebPage;
namespace EventsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get The all web pages
            WebPageProvider webPageProvider = new WebPageProvider();
            IEnumerable<IWebPage> webPages = webPageProvider.All();

            //Get all the logic for web pages
            ConversionLogicsProvider clp = new ConversionLogicsProvider();
            IEnumerable<IConversionLogicsForWebPage> conversionLogicsForWebPages = clp.All();

            //Persist what is being passed to Engine01


            Engine01 engine = new Engine01();
            engine.WebPages = webPages;
            engine.WebConversionRules = conversionLogicsForWebPages;

            engine.Run();
        }
    }
}
