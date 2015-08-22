using System.Collections.Generic;
using EventsAggregator.DataContracts;
using EventsAggregator.DataObjects;
using EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces;
using EventsAggregator.StructuralObjects;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor
{
    class ProcessDataContainer : IProcessDataContainer 
    {
        private IWebPage _webPage;
        private HtmlDocument _document;
        private TextTable _textTable;

        public IWebPage WebPage
        {
            get { return _webPage; }
            set
            {
                _webPage = value;
                foreach (IDataChangedNotifiable observer in Observers)
                {
                    observer.WebPageIsSet(_webPage);
                }
            }
        }

        public HtmlDocument Document
        {
            get { return _document; }
            set
            {
                _document = value;
                foreach (IDataChangedNotifiable observer in Observers)
                {
                    observer.DocumentIsSet(_document);
                }
            }
        }

        public TextTable TextTable
        {
            get { return _textTable; }
            set
            {
                _textTable = value;
                foreach (IDataChangedNotifiable observer in Observers)
                {
                    observer.TextTableIsSet(_textTable);
                } 
            }
        }

        public IEnumerable<IDataChangedNotifiable> Observers { get; set; }
    }
    
}