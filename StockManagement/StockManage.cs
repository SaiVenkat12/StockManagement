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
        int amount = 10000;
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
        public void BuyStock(string name)
        {
            double amount = 1000; int count = 0;
            foreach (var data in StockMarket)
            {
                
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter the number of stocks you need to buy : ");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks * data.StockPrice <= amount && noOfStocks <= data.NoOfShares)
                    {
                        Model details = new Model()
                        {
                            StockName = data.StockName,
                            StockPrice = data.StockPrice,
                            NoOfShares = noOfStocks
                        };
                        data.NoOfShares -= noOfStocks;
                        amount -= noOfStocks * data.StockPrice;                    
                        foreach (var account in Customer)
                        {
                            if (account.StockName.Equals(name))
                            {
                                count++;
                            }
                            account.NoOfShares += noOfStocks;
                        }
                        if (count == 1)
                        {
                            data.NoOfShares += noOfStocks;                           
                        }
                        else
                        {
                            Customer.Add(details);
                        }
                    }
                }
            }
        }
        public void SellStock(string name)
        {
            foreach (var data in Customer)
            {
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter the number of stocks you need to sell");
                    int sellStocks = Convert.ToInt32(Console.ReadLine());
                    if (sellStocks <= data.NoOfShares)
                    {
                        data.NoOfShares -= sellStocks;
                        amount += data.StockPrice * sellStocks;

                        foreach (var account in StockMarket)
                        {
                            if (account.StockName.Equals(name))
                            {
                                data.NoOfShares -= sellStocks;
                                return;
                            }
                        }

                    }
                }
            }
        }
        public void WriteToStockJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(StockMarket);
            File.WriteAllText(filepath, json);
        }
        public void WriteToCustomerJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(Customer);
            File.WriteAllText(filePath, json);
        }
    }
}



                    
                
