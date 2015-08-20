using System.Collections.Generic;
using EventsAggregator.Entities.BO;
using EventsAggregator.Infrastructure;
using HtmlAgilityPack;

namespace EventsAggregator.Builders.WebPage
{
    class CanberraEventsPageConversionLogic : IConversionLogic
    {
        public TextTable Convert(HtmlDocument document)
        {
            var page = document.GetElementbyId("page");
            var namelessDiv = page.ChildNodes[0];

            //the idiots are using one table per event!
            HtmlNodeCollection tables = namelessDiv.SelectNodes("//table");

            TextTable textTable = new TextTable();

            List<TextRow> textRows = new List<TextRow>();
            foreach (HtmlNode table in tables)
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    TextRow textRow = new TextRow();

                    List<string> cells = new List<string>();
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        cells.Add(cell.InnerHtml);
                    }
                    textRow.Cells = cells;

                    textRows.Add(textRow);
                }
                textTable.Rows = textRows;
            }

            return textTable;
        }
    }
}