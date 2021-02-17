﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using BasicWebServer;

namespace MyWebServerUrlPArser
{
    class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }


            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }

                // get url 
                Console.WriteLine($"Received request for {request.Url}");

                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);

                // parse path in url 
                //foreach (string str in request.Url.Segments)
                // {
                //   Console.WriteLine(str);
                //}
                string[] segments = request.Url.Segments;

                //Console.WriteLine(segments[1]);

                string result = "no result";
                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                if (segments[1] == "mymethods/")
                {
                    Type type = typeof(BasicWebServer.MyMethods);
                    MethodInfo method = type.GetMethod(segments[2].TrimEnd('/'));
                    BasicWebServer.MyMethods c = new MyMethods();
                    object[] tab = new object[2];
                    tab[0] = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                    tab[1] = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");
                    if (method != null)
                    {
                        result = (string)method.Invoke(c, tab);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Methode non trouvé");
                    }
                    //Console.WriteLine(result);
                } else if (segments[1] == "webservice/")
                {
                    Type type = typeof(BasicWebServer.MyMethods);
                    MethodInfo method = type.GetMethod(segments[2].TrimEnd('/'));
                    BasicWebServer.MyMethods c = new MyMethods();
                    object[] tab = new object[1];
                    tab[0] = HttpUtility.ParseQueryString(request.Url.Query).Get("val");
                    if (method != null)
                    {
                        result = (string)method.Invoke(c, tab);
                        response.ContentType = "application/json";
                        Console.WriteLine(result);
                    }
                }

                //Console.ReadLine();

                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);

                //parse params in url
                Console.WriteLine("param1 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param1"));
                Console.WriteLine("param2 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param2"));
                Console.WriteLine("param3 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param3"));
                Console.WriteLine("param4 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param4"));

                //
                Console.WriteLine(documentContents);

    

                // Construct a response.
                string responseString =  result;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }
}
