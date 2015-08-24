using System.Collections.Generic;

namespace EventsAggregator.StructuralObjects
{
    public class TextRow
    {
        public TextRow()
        {
        }

        public IEnumerable<string> Cells { get; set; }
    }
}