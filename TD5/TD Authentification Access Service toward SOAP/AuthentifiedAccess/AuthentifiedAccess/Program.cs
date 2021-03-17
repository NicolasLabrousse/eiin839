using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthentifiedAccess
{
    class Program
    {

        static void Main(string[] args)
        {

            AuthenticatorSOAP.AuthenticatorClient auth = new AuthenticatorSOAP.AuthenticatorClient();
            WeatherSOAP.ServiceAccessClient weather = new WeatherSOAP.ServiceAccessClient();

            Console.WriteLine("Enter username : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();

            bool isvalid = auth.ValidateCredentials(username, password);
            if(isvalid)
            {
                Console.WriteLine("Your are authenticated!");
                Console.WriteLine("enter a city name:");
                string city = Console.ReadLine();
                Console.WriteLine(weather.weather(city));

            } 
            else
                Console.WriteLine("Your are NOT authenticated!");
            Console.ReadLine();     
        }
    }
}
