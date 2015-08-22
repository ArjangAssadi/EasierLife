using System.Collections.Generic;
using EventsAggregator.DataContracts;
using EventsAggregator.DataObjects;
using EventsAggregator.StructuralObjects;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces
{
    internal interface IProcessDataContainer
    {
        IWebPage WebPage { get; set; }
        HtmlDocument Document { get; set; }
        TextTable TextTable { get; set; }

        IEnumerable<IDataChangedNotifiable> Observers { get; set; }
    }
}