namespace StockManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to stock Account Management");
            StockManage management = new StockManage();
            string stockFilePath = @"C:\Users\venky\source\StockManagement\StockManagement\StockMarket.json";
            string customerFilePath = @"C:\Users\venky\source\StockManagement\StockManagement\Customer.json";

            management.ReadStockJsonFile(stockFilePath);
            management.ReadCustomerJsonFile(customerFilePath);
            management.BuyStock("Google");
            management.SellStock("Apple");
            management.WriteToStockJsonFile(stockFilePath);
            management.WriteToCustomerJsonFile(customerFilePath);
        }
    }
}
