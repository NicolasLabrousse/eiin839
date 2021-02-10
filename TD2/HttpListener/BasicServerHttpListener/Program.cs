using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BasicServerHTTPlistener
{
    internal class Program
    {
        private static void Main(string[] args)
        {
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
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                // Récupère le header de la requete
                // l'envoi a notre classe pour récupérer les champs du header
                Header header = new Header((WebHeaderCollection)request.Headers);
                // Affiche dans la console les attributs du header s
                Console.WriteLine(header);

                //Console.WriteLine(request.Headers);

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                Console.WriteLine($"Received request for {request.Url}");
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ...
            // listener.Stop();
        }
    }

    internal class Header
    {

        WebHeaderCollection webHeaderCollection;

        // Ici une sélection d'attribut du header
        // On peut en rajouter il faudra penser à le parser dans le constructeur
        private string accept;
        private string acceptCharset;
        private string acceptEncoding;
        private string acceptLanguage;
        private string allow;
        private string authorization;
        private string cookie;
        private string from;
        private string userAgent;



        //Constructeur par défaut
        // Parsing
        public Header(WebHeaderCollection headerCollection)
        {
            this.webHeaderCollection = headerCollection;
            // Les  types  MIME admis  pour la  réponse,
            if (this.webHeaderCollection.Get("Accept") != null) this.accept = this.webHeaderCollection.Get("Accept");
            // Les  jeux de  caractères  admis  pour  la  réponse, 
            if (this.webHeaderCollection.Get("Accept-Charset") != null) this.acceptCharset = this.webHeaderCollection.Get("Accept-Charset");
            // Les  encodages  de contenu  admis  pour  la  réponse,
            if (this.webHeaderCollection.Get("Accept-Encoding") != null) this.acceptEncoding = this.webHeaderCollection.Get("Accept-Encoding");

            // Les  langages  naturels  préférés  pour  la  réponse,
            if (this.webHeaderCollection.Get("Accept-Language") != null) this.acceptLanguage = this.webHeaderCollection.Get("Accept-Language");

            // Le  jeu  de  méthodes  HTTP  pris  en charge, 
            if (this.webHeaderCollection.Get("Allow") != null) this.allow = this.webHeaderCollection.Get("Allow");

            // Les informations d’identification que le client doit présenter pour s’authentifier auprès du serveur, 
            if (this.webHeaderCollection.Get("Authorization") != null) this.authorization = this.webHeaderCollection.Get("Authorization");

            // Les données  de  cookie  présentées  au  serveur,
            if (this.webHeaderCollection.Get("Cookie") != null) this.cookie = this.webHeaderCollection.Get("Cookie");

            // L’adresse  e-mail Internet pour l’utilisateur humain qui contrôle l’agent utilisateur demandeur,
            if (this.webHeaderCollection.Get("From") != null) this.from = this.webHeaderCollection.Get("From");

            // Les informations relatives à l’agent client
            if (this.webHeaderCollection.Get("User-Agent") != null) this.userAgent = this.webHeaderCollection.Get("User-Agent");
  
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            if (this.accept != null) sb.Append("Accept : " + this.accept + "\n");
            if (this.acceptCharset != null) sb.Append("Accept Charset : " + this.acceptCharset + "\n");
            if (this.acceptEncoding != null) sb.Append("Accept Encoding : " + this.acceptEncoding + "\n");
            if (this.acceptLanguage != null) sb.Append("Accept Language : " + this.acceptLanguage + "\n");
            if (this.allow != null) sb.Append("Allow : " + this.allow + "\n");
            if (this.authorization != null) sb.Append("Authorization : " + this.authorization + "\n");
            if (this.cookie != null) sb.Append("Cookie : " + this.cookie + "\n");
            if (this.from != null) sb.Append("From : " + this.from + "\n");
            if (this.userAgent != null) sb.Append("User Agent : " + this.userAgent + "\n");
            return sb.ToString();
        }
    }
}