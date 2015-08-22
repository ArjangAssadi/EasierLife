using System.Collections.Generic;
using System.Linq;
using EventsAggregator.CodeContracts;
using EventsAggregator.DataContracts;
using EventsAggregator.StructuralObjects;
using HtmlAgilityPack;

namespace EventsAggregator.CodeObjects.Engines
{
    internal class Engine01
    {
        private List<TextTable> _pageTextData;

        public Engine01()
        {
            _pageTextData = new List<TextTable>();
        }

        public IEnumerable<IConversionLogicsForWebPage> WebConversionRules { get; set; }
        public IEnumerable<IWebPage> WebPages { get; set; }

        public void Run()
        {
            foreach (IWebPage webPage in WebPages)
            {
                IEnumerable<IConversionLogicsForWebPage> conversionLogicsForWebPages = GetRuleForPages(webPage);
                foreach (IConversionLogicsForWebPage conversionLogicsForWebPage in conversionLogicsForWebPages)
                {
                    HtmlDocument htmlDocument = conversionLogicsForWebPage.Convert(webPage);
                    TextTable textTable = conversionLogicsForWebPage.Convert(htmlDocument);
                    _pageTextData.Add(textTable);
                }
            }
        }

        public object PageTextData
        {
            get { return _pageTextData; }
        }

        private IEnumerable<IConversionLogicsForWebPage> GetRuleForPages(IWebPage webPage)
        {
            //from conversion rules select the rule that has the same id as the page
            return WebConversionRules.Where(item => item.Id == webPage.Id);
        }
    }
}