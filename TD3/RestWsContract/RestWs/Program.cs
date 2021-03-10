using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestWs
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v3/contracts?apiKey=67b2054c6e21e957152012426c86ed264fb1745c");
                List<Contract> contracts = JsonSerializer.Deserialize<List<Contract>>(responseBody);
                foreach (var contract in contracts)
                {
                    Console.WriteLine(contract);
                }

                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            Console.Read();
        }
    }

    class Contract
    {

        public string name { get; set; }
        public string commercial_name { get; set; }
        public string[] cities { get; set; }
        public string country_code { get; set; }

        public Contract() { }
            
        public override string ToString()
        {
            return "name :" + name + " Commercial Name: " + commercial_name + " CountryCode: " + country_code;
        }

    }
}
