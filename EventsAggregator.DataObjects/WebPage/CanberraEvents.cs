using System;
using EventsAggregator.DataContracts;

namespace EventsAggregator.DataObjects.WebPage
{
    public class CanberraEvents : IWebPage
    {
        private int _id;
        private string _description;
        private Uri _uri;

        public CanberraEvents()
        {
            _id = 1;
            _description = "Canberra Events";
            _uri = new Uri("http://www.events.act.gov.au/index.php?Itemid=300&amp;option=com_events&amp;view=events&amp;category=-1&amp;from=19-08-2015&amp;to=31-03-2016&limitstart=0&limit=-1");
        }

        public int Id
        {
            get { return _id; }
        }

        public string Description
        {
            get { return _description; }
        }

        public Uri Uri
        {
            get { return _uri; }
        }
    }
}
