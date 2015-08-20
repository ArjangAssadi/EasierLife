using System;
using System.Collections.Generic;
using EventsAggregator.Builders;
using EventsAggregator.Entities.BO;

namespace EventsAggregator.Providers.WebPage
{
    class WebPageProvider
    {
        public IEnumerable<IWebPage> All()
        {
            IList<IWebPage> result = new List<IWebPage>();

            WebPageBuilder wpb = new WebPageBuilder();
            
            result.Add(wpb.Build(1));

            return result;
        }
    }
}
