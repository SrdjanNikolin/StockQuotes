namespace StockQuotes
{
    class StockQuoteFileLoader : IStockQuoteLoader
    {
        public string GetQuotes(string path)
        {
            string stocks = System.IO.File.ReadAllText(path);
            return stocks;
        }
    }
}