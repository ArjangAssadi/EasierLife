using System.Collections.Generic;
using EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces;
using HtmlAgilityPack;

namespace EventsAggregator.Parts.WebPageToTextTableExtractor
{
    internal class WebPageToTextTableExtractor : IWebPageToTextTableExtractor
    {
        public WebPageToTextTableExtractor()
        {
            _observers = new List<IDataChangedNotifiable>();
        }

        public IProcessDataContainer ProcessDataContainer;

        private IList<IDataChangedNotifiable> _observers;

        private IProcessingLogicContainer _processingLogicContainer;
        private IProcessDataContainer _processingDataContainer;

        IProcessDataContainer IWebPageToTextTableExtractor.ProcessingDataContainer
        {
            get { return _processingDataContainer; }
            set
            {
                _processingDataContainer = value;
                _processingDataContainer.Observers = _observers;
            }
        }

        public IProcessingLogicContainer ProcessingLogicContainer
        {
            get { return _processingLogicContainer; }

            set { _processingLogicContainer = value; }
        }
        
        public void Register(IDataChangedNotifiable observer)
        {
            _observers.Add(observer);
        }

        public void UnRegister(IDataChangedNotifiable observer)
        {
            _observers.Remove(observer);
        }
    }
}