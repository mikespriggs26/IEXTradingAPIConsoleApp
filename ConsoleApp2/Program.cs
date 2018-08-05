using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //  This console application uses the IEX Trading API to retrieve stock data and market data
            //
            Console.WriteLine("Please enter a ticker symbol: ");
            var symbol = Console.ReadLine();
            var IEXTrading_API_PATH = "https://api.iextrading.com/1.0/stock/{0}/company";

            IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, symbol);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //For IP-API
                client.BaseAddress = new Uri(IEXTrading_API_PATH);
                HttpResponseMessage response = client.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();
               

                if (response.IsSuccessStatusCode)
                {
                    var historicalDataList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    
                    string myResult = historicalDataList.ToString();
                    
                    CompanyResponse item = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyResponse>(myResult);
                    Console.WriteLine("Company name: " + item.companyName);
                    Console.WriteLine("Symbol: " + item.symbol);
                    Console.WriteLine("Exchange: " + item.exchange);
                    Console.WriteLine("Industry: " + item.industry);
                    Console.WriteLine("Website: " + item.website);
                    Console.WriteLine("CEO: " + item.CEO);
                    Console.WriteLine("Issue Type: " + item.issueType);
                    Console.WriteLine("Sector: " + item.sector);
                    Console.WriteLine("Description: " + item.description);
                    
                    
                }//if clause


            }//using statement
            Console.WriteLine("Please enter a ticker symbol: ");
            var symbol2 = Console.ReadLine();
            var IEXTrading_API_PATH2 = "https://api.iextrading.com/1.0/stock/{0}/price";

            IEXTrading_API_PATH2 = string.Format(IEXTrading_API_PATH2, symbol2);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //For IP-API
                client.BaseAddress = new Uri(IEXTrading_API_PATH2);
                HttpResponseMessage response = client.GetAsync(IEXTrading_API_PATH2).GetAwaiter().GetResult();
                
                if (response.IsSuccessStatusCode)
                {
                    var historicalDataList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    string myResult = historicalDataList.ToString();
                    
                    Console.WriteLine("Price: " + myResult);
                
                }


            }
            Console.ReadKey();
            
        }
       
        public class StockPriceResponse
        {
            public string price { get; set; }
        }
        public class CompanyResponse
        {
            public string symbol { get; set; }
            public string companyName { get; set; }
            public string exchange { get; set; }
            public string industry { get; set; }
            public string website { get; set; }
            public string description { get; set; }
            public string CEO { get; set; }
            public string issueType { get; set; }
            public string sector { get; set; }
            public List<string> tags { get; set; }
        }
    }
}




