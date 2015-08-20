using System;
using EventsAggregator.Infrastructure;
using HtmlAgilityPack;

namespace EventsAggregator.Entities.BO
{
    internal interface IWebPage
    {
        int Id { get; set; }
        string Description { get; set; }
        Uri Uri { get; set; }
        IConversionLogic ConversionLogic { get; set; }
    }

    internal class WebPage : IWebPage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public  Uri Uri{ get; set; }
        public IConversionLogic ConversionLogic { get; set; }
    }

    interface IConversionLogic
    {
        TextTable Convert(HtmlDocument document);
    }


}