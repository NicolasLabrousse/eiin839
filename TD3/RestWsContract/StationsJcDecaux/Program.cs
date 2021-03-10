﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StationsJcDecaux
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                string contractname = args[0];
                string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v3/stations?apiKey=67b2054c6e21e957152012426c86ed264fb1745c&contract=" +contractname);
                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);
                foreach (var station in stations)
                {
                    Console.WriteLine(station);
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

    public class Station
    {
        public int number { get; set; }
        public string contractName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public override string ToString()
        {
            return " number : " + number + "\n"
                 + " contractName : " + contractName + "\n"
                 + " name : " + name + "\n"
                 + " address : " + address + "\n"
                 + " position : [" + position + "]\n";
        }
    }
    public class Position
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public override string ToString()
        {
            return "latitude : " + latitude + " longitude : " + longitude;
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

