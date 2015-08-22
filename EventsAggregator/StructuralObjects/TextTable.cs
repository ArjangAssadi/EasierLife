using System.Collections.Generic;

namespace EventsAggregator.StructuralObjects
{
    public class TextTable  
    {
        public IEnumerable<TextRow> Rows { get; set; } 
    }
}