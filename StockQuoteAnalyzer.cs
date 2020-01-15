using System.Collections.Generic;
using System.Linq;

namespace StockQuotes
{
    class StockQuoteAnalyzer
    {
        public List<Change> GetChanges(string data, IParser parser)
        {
            StockQuoteHandler handler = new StockQuoteHandler();
            List<Change> changes = new List<Change>();
            
            List<StockQuote> stockQuotes = parser.Parse(data).ToList();
            changes = handler.AnalyseQuotes(stockQuotes);
            return changes;
        }
    }
}