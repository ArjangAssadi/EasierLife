using System;
using EventsAggregator.Builders.WebPage;
using EventsAggregator.Entities.BO;

namespace EventsAggregator.Builders
{
    class WebPageBuilder
    {
        public IWebPage Build(int id)
        {
            IWebPage result = new Entities.BO.IWebPage();

            if (id == 1)
            {
                result.Id = 1;
                result.Uri =
                    new Uri(
                        "http://www.events.act.gov.au/index.php?Itemid=300&amp;option=com_events&amp;view=events&amp;category=-1&amp;from=19-08-2015&amp;to=31-03-2016&limitstart=0&limit=-1");
                result.Description = "Canberra Events";
                result.ConversionLogic = new CanberraEventsPageConversionLogic();
            }

            return result;
        }
    }
}
