using System.Collections.Generic;

namespace StockQuotes
{
    class StockQuoteHandler
    {
        public List<Change> AnalyseQuotes(List<StockQuote> quotes)
        {         
        List<Change> changes = new List<Change>();
        for (int index = 0; index < quotes.Count - 1; index++)
        {
            if (quotes[index].High < quotes[index + 1].Open && quotes[index].Low > quotes[index + 1].Close)
            {
                changes.Add(new Change() { Direction = Directions.DOWN, StockQuote = quotes[index] });
            }
            else if (quotes[index].Low > quotes[index + 1].Open && quotes[index].High < quotes[index + 1].Close)
            {
                changes.Add(new Change() { Direction = Directions.UP, StockQuote = quotes[index] });
            }
        }

        return changes;
        }
    }
}