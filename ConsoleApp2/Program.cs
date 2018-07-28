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
            //var symbol = "msft";
            //var IEXTrading_API_PATH = "https://api.iextrading.com/1.0/stock/{0}/chart/1y";

            //IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, symbol);

            //using (HttpClient client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    //For IP-API
            //    client.BaseAddress = new Uri(IEXTrading_API_PATH);
            //    HttpResponseMessage response = client.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var historicalDataList = response.Content.ReadAsAsync<List<HistoricalDataResponse>>().GetAwaiter().GetResult();
            //        foreach (var historicalData in historicalDataList)
            //        {
            //            if (historicalData != null)
            //            {
            //                Console.WriteLine("Open: " + historicalData.open);
            //                Console.WriteLine("Close: " + historicalData.close);
            //                Console.WriteLine("Low: " + historicalData.low);
            //                Console.WriteLine("High: " + historicalData.high);
            //                Console.WriteLine("Change: " + historicalData.change);
            //                Console.WriteLine("Change Percentage: " + historicalData.changePercent);
            //            }
            //        }
            //    }
            var symbol = "msft";
            var IEXTrading_API_PATH = "https://api.iextrading.com/1.0/stock/{0}/company";

            IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, symbol);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //For IP-API
                client.BaseAddress = new Uri(IEXTrading_API_PATH);
                HttpResponseMessage response = client.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();
                //string myResponse = response;

                if (response.IsSuccessStatusCode)
                {
                    var historicalDataList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Console.WriteLine(historicalDataList);
                    string myResult = historicalDataList.ToString();
                    Console.WriteLine(myResult);
                    CompanyResponse item = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyResponse>(myResult);
                    Console.WriteLine(item.companyName);
                    //CompanyResponse[] items = JsonConvert.DeserializeObject<CompanyResponse[]>(myResult);

                    //foreach (var historicalData in items)
                    //{
                    //    if (historicalDataList != null)
                    //    {
                    //        Console.WriteLine(historicalData);


                            Console.ReadKey();
                    //    }
                    //}
                }


            }
        }
        public class HistoricalDataResponse
        {
            public string date { get; set; }
            public double open { get; set; }
            public double high { get; set; }
            public double low { get; set; }
            public double close { get; set; }
            public int volume { get; set; }
            public int unadjustedVolume { get; set; }
            public double change { get; set; }
            public double changePercent { get; set; }
            public double vwap { get; set; }
            public string label { get; set; }
            public double changeOverTime { get; set; }
        }
        public class StockPriceResponse
        {
            public double price { get; set; }
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




