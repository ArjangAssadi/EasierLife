using EventsAggregator.DataContracts;
using EventsAggregator.StructuralObjects;
using HTMLAgilityPackWrapper;

namespace EventsAggregator.CodeContracts
{
    public interface IConversionLogicsForWebPage
    {
        int Id { get; }
        HTMLAgilityPackWrapper.HtmlDocument Convert(IWebPage webPage);
        TextTable Convert(HTMLAgilityPackWrapper.HtmlDocument document);
    }
}
