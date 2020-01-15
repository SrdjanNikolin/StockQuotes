using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace StockQuotes
{
    class StockQuoteXMLParser : IParser
    {
        public IEnumerable<StockQuote> Parse(string file)
        {
            XDocument doc = XDocument.Parse(file);

            IEnumerable<StockQuote> result = from stockQuote in doc.Descendants("stockQuote")
                                             select new StockQuote
                                             {
                                                 Date = DateTime.Parse(stockQuote.Element("date").Value),
                                                 Open = float.Parse(stockQuote.Element("open").Value),
                                                 High = float.Parse(stockQuote.Element("high").Value),
                                                 Low = float.Parse(stockQuote.Element("low").Value),
                                                 Close = float.Parse(stockQuote.Element("close").Value),
                                             };
            return result;
        }
    }
}