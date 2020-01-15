using System.Collections.Generic;

namespace StockQuotes
{
    public interface IParser
    {
        IEnumerable<StockQuote> Parse(string data);
    }
}