using System.Collections.Generic;
using EventsAggregator.DataContracts;
using EventsAggregator.DataObjects.WebPage;

namespace EventsAggregator.Providers.WebPage
{
    class WebPageProvider
    {
        public IEnumerable<IWebPage> All()
        {
            IList<IWebPage> result = new List<IWebPage>();

            result.Add(new CanberraEvents());

            return result;
        }
    }
}
