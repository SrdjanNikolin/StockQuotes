using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace StockQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            StockQuoteAnalyzer analyzer = new StockQuoteAnalyzer();
            List<string> filepaths = new List<string>
            {
                ConfigurationManager.AppSettings["filepath"],
                ConfigurationManager.AppSettings["webpath"],
                ConfigurationManager.AppSettings["xmlpath"]
            };

            Random random = new Random();
            int index = random.Next(0, filepaths.Count);
            string filePath = filepaths[index];

            IStockQuoteLoader stockQuoteLoader = PathLoader(filePath);
            IParser parser = ParseChooser(filePath);

            List<Change> changes = analyzer.GetChanges(stockQuoteLoader.GetQuotes(filePath), parser);
            foreach (var change in changes)
            {
                if (change.Direction == Directions.UP)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(change.Direction + ":" + change.StockQuote.Date);
                    Console.ResetColor();
                }
                else if (change.Direction == Directions.DOWN)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(change.Direction + ":" + change.StockQuote.Date);
                    Console.ResetColor();
                }
            }
        }
        public static IStockQuoteLoader PathLoader(string path)
        {
            IStockQuoteLoader loader = null;
            bool isUri = Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute);
            Console.WriteLine(path);
            if (isUri)
            {
                loader = new StockQuoteWebLoader();
            }
            else if (new Uri(path).IsFile)
            {
                loader = new StockQuoteFileLoader();
            }
            else
            {
                Console.WriteLine("Invalid path");
                loader = null;
            }
            return loader;
        }
        public static IParser ParseChooser(string path)
        {
            string extension = Path.GetExtension(path);
            IParser parser;
            if (extension == ".csv")
            {
                parser = new StockQuoteCSVParser();
            }
            else if (extension == ".xml")
            {
                parser = new StockQuoteXMLParser();
            }
            else
            {
                parser = new StockQuoteCSVParser();
            }
            return parser;
        }
    }
}