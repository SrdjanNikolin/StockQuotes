using System;
using System.Collections.Generic;
using System.Linq;

namespace StockQuotes
{
    class StockQuoteCSVParser : IParser
    {
        public StockQuote ParseRow(string row)
        {
            try
            {
                string[] split = row.Split(',');
                DateTime currentDate = DateTime.Parse(split[0]);
                double currentHigh = double.Parse(split[2]);
                double currentLow = double.Parse(split[3]);
                double beforeOpen = double.Parse(split[1]);
                double beforeClose = double.Parse(split[4]);
                return new StockQuote() { Date = currentDate, High = currentHigh, Low = currentLow,
                    Open = beforeOpen, Close = beforeClose };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<StockQuote> Parse(string file)
        {
            string[] splitFile = file.Split('\n');
            IEnumerable<StockQuote> result = from row in splitFile
                                             where ParseRow(row)!=null
                                             select new StockQuote { Date = ParseRow(row).Date, High = ParseRow(row).High,
                                                 Low = ParseRow(row).Low, Open = ParseRow(row).Open, Close = ParseRow(row).Close };
            return result;
        }
    }
}