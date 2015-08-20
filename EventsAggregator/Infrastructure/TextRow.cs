using System.Collections;
using System.Collections.Generic;

namespace EventsAggregator.Infrastructure
{
    public class TextRow
    {
        public TextRow()
        {
        }

        public IEnumerable<string> Cells { get; set; }
    }
}