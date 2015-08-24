using System.Collections.Generic;
using EventsAggregator.CodeContracts;
using EventsAggregator.CodeObjects.ConversionLogic;

namespace EventsAggregator.Providers.ConversionLogics
{
    public class ConversionLogicsProvider
    {
        public IEnumerable<IConversionLogicsForWebPage> All()
        {
            IList<IConversionLogicsForWebPage> result = new List<IConversionLogicsForWebPage>();

            result.Add(new ConversionLogicsForCanberraEventsWebPage() );

            return result;
        }
    }
}
