namespace EventsAggregator.Parts.WebPageToTextTableExtractor.Interfaces
{
    interface IWebPageToTextTableExtractor
    {
        IProcessDataContainer ProcessingDataContainer { get; set; }
        IProcessingLogicContainer ProcessingLogicContainer { get; set; }
        void Register(IDataChangedNotifiable observer);
        void UnRegister(IDataChangedNotifiable observer);
    }
}