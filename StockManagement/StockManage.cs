using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class StockManage
    {
        double amount = 1000;
        Model Stocks = new Model();
        List<Model> StockMarket = new List<Model>();
        List<Model> Customer = new List<Model>();

        public void ReadStockJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.StockMarket = JsonConvert.DeserializeObject<List<Model>>(json);
            Console.WriteLine("Stock Market");
            foreach (var content in StockMarket)
            {
                Console.WriteLine("StockName: " + content.StockName + " StockPrice: " + content.StockPrice + " NoOfShares " + content.NoOfShares);
            }
        }
        public void ReadCustomerJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.Customer = JsonConvert.DeserializeObject<List<Model>>(json);
            Console.WriteLine("Customer");
            foreach (var content in Customer)
            {
                Console.WriteLine("StockName: " + content.StockName + " StockPrice: " + content.StockPrice + " NoOfShares " + content.NoOfShares);
            }
        }

    }
}
