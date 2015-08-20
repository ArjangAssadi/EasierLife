using System.Collections.Generic;

namespace EventsAggregator.Infrastructure
{
    public class TextTable  
    {
        public IEnumerable<TextRow> Rows { get; set; } 
    }
}