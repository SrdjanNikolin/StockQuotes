using System.Net;

namespace StockQuotes
{
    class StockQuoteWebLoader : IStockQuoteLoader
    {
        public string GetQuotes(string path)
        {
            string stocks = string.Empty;
            using (WebClient wc = new WebClient())
            {
                stocks = wc.DownloadString(path);
            };

            return stocks;
        }
    }
}