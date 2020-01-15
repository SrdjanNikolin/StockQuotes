namespace StockQuotes
{
    interface IStockQuoteLoader
    {
        string GetQuotes(string path);
    }
}