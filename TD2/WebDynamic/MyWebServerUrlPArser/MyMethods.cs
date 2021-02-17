using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicWebServer
{
    class MyMethods
    {

        public string MyMethod(string param1, string param2)
        {
            return "<HTML><BODY> Hello " + param1 + " et " + param2 + " </BODY></HTML>";
        }

        public string MyMethodExternal(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\nicon\source\repos\NicolasLabrousse\eiin839\TD2\WebDynamic\MyExternalMethods\bin\Debug\netcoreapp3.1\MyExternalMethods.exe"; // Specify exe name.
            start.Arguments = param1 + " " + param2; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                    //Console.WriteLine(result);
                    //Console.ReadLine();
                }
            }
        }

        public string Incr(string value)
        {

            string valIncr =  (int.Parse(value) + 1).ToString();
            string jsonString = "{\"val\":" + valIncr + ", \"success\": true }";
            return jsonString;
        }

    }
}

