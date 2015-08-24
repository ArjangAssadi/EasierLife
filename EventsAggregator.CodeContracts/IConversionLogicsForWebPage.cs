using EventsAggregator.DataContracts;
using EventsAggregator.StructuralObjects;
using HtmlAgilityPack;

namespace EventsAggregator.CodeContracts
{
    public interface IConversionLogicsForWebPage
    {
        int Id { get; }
        HtmlDocument Convert(IWebPage webPage);
        TextTable Convert(HtmlDocument document);
    }
}