using CentricaTestClient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CentricaTestClient.WPF.Callers
{
    public class DistrictCaller
    {
        public async Task<IEnumerable<District>> GetAllDistricts()
        {
            IEnumerable<District> districts = new List<District>();
            //HttpClientHandler authHandler = new HttpClientHandler()
            //{
            //    Credentials = new NetworkCredential("tubcase@hotmail.com", "1Hk98dpfIeeK")
            //};
            //using (var client = new HttpClient(authHandler))
            //{
            //    client.BaseAddress = new Uri($"http://localhost:51155");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response = client.GetAsync("api/district/getall").Result;

            //    if (response.IsSuccessStatusCode)
            //    {
            //        districts = await response.Content.ReadAsAsync<IEnumerable<District>>();
            //    }
            //    else
            //    {
            //        WE DEAD

            //    }
            //}
            Uri uri = new Uri($"https://localhost:44337/api/district/getall");
            WebClient client = new WebClient();
            //client.Credentials = CredentialCache.DefaultCredentials;

            //TODO Constants needs to be created, as it is for windows auth purposes and uses real usernam password atm
            client.Credentials = new NetworkCredential(Constants.userName, Constants.passWord);

            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = sr.ReadToEnd();
                    Console.WriteLine(result);

                    districts = JsonConvert.DeserializeObject<IEnumerable<District>>(result);                    
                }
            }
            return districts;
        }
    }
}
