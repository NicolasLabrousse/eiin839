using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AuthentifiedAccessSOAP
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Authenticator : IAuthenticator
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool ValidateCredentials(string username, string password)
        {
            Dictionary<string, string> Credentials = new Dictionary<string, string>();
            string[] logins = File.ReadAllLines(@"..\..\..\passwd.csv");
                foreach (string login in logins)
                {
                    string[] parts = login.Split(';');
                    Credentials.Add(parts[0].Trim(), parts[1].Trim());
                }
            return Credentials.Any(entry => entry.Key == username && entry.Value == password);
        }
    }
}
