using System;
using System.IO;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri($"https://localhost:44337/api/district/getall");
            WebClient client = new WebClient();
            //client.Credentials = CredentialCache.DefaultCredentials;
            client.Credentials = new NetworkCredential("tubcase@hotmail.com", "1Hk98dpfIeeK");
            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = sr.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
