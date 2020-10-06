using CentricaTestClient.Domain.Models;
using CentricaTestClient.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestClient.CentricaTestAPI.Services
{
    public class DistrictService : IDistrictService
    {
        private string _userName;
        private string _password;

        public DistrictService(string userName, string passWord)
        {
            _userName = userName;
            _password = passWord;
        }

        public async Task<IEnumerable<District>> GetAllDistricts()
        {
            IEnumerable<District> districts = new List<District>();
            Uri uri = new Uri($"https://localhost:44337/api/district/getall");
            WebClient client = new WebClient();

            //TODO Constants needs to be created, as it is for windows auth purposes and uses real usernam password atm
            client.Credentials = new NetworkCredential(_userName, _password);

            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = await sr.ReadToEndAsync();
                    Console.WriteLine(result);

                    districts = JsonConvert.DeserializeObject<IEnumerable<District>>(result);
                }
            }
            return districts;
        }

        public async Task<IEnumerable<Salesman>> GetAllSalesmenInDistrict(string id)
        {
            IEnumerable<Salesman> salesman = new List<Salesman>();
            Uri uri = new Uri($"https://localhost:44337/api/district/" + id + "/GetAllSalesman");
            WebClient client = new WebClient();

            //TODO Constants needs to be created, as it is for windows auth purposes and uses real usernam password atm
            client.Credentials = new NetworkCredential(_userName, _password);

            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = await sr.ReadToEndAsync();
                    Console.WriteLine(result);

                    salesman = JsonConvert.DeserializeObject<IEnumerable<Salesman>>(result);
                }
            }
            return salesman;
        }

        public async Task<IEnumerable<Store>> GetAllStoresInDistrict(string id)
        {
            IEnumerable<Store> store = new List<Store>();
            Uri uri = new Uri($"https://localhost:44337/api/district/" + id + "/GetAllStores");
            WebClient client = new WebClient();

            //TODO Constants needs to be created, as it is for windows auth purposes and uses real usernam password atm
            client.Credentials = new NetworkCredential(_userName, _password);

            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = await sr.ReadToEndAsync();
                    Console.WriteLine(result);

                    store = JsonConvert.DeserializeObject<IEnumerable<Store>>(result);
                }
            }
            return store;
        }

        public async Task<IEnumerable<Salesman>> GetAllSalesmenOutsideDistrict(string id)
        {
            IEnumerable<Salesman> salesman = new List<Salesman>();
            Uri uri = new Uri($"https://localhost:44337/api/district/" + id + "/GetAllForeignSalesman");
            WebClient client = new WebClient();

            //TODO Constants needs to be created, as it is for windows auth purposes and uses real usernam password atm
            client.Credentials = new NetworkCredential(_userName, _password);

            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = await sr.ReadToEndAsync();
                    Console.WriteLine(result);

                    salesman = JsonConvert.DeserializeObject<IEnumerable<Salesman>>(result);
                }
            }
            return salesman;
        }

        public async Task<bool> AddSalesmanToDistrict(string id, Salesman salesman)
        {
            bool result = false;
            Uri uri = new Uri($"https://localhost:44337/api/district/" + id + "/AddSalesmanToDistrict");
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(_userName, _password);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var response = client.UploadString(uri,
                        WebRequestMethods.Http.Put,
                        JsonConvert.SerializeObject(salesman));

                    //TODO ALTER LATER
                    if (response != null)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<bool> RemoveSalesmanFromDistrict(string id, Salesman salesman)
        {
            bool result = false;
            Uri uri = new Uri($"https://localhost:44337/api/district/" + id + "/RemoveSalesmanFromDistrict");
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(_userName, _password);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var response = client.UploadString(uri,
                        "DELETE",
                        JsonConvert.SerializeObject(salesman));

                    //TODO ALTER LATER
                    if (response != null)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<bool> PromotePrimarySalesmanInDistrict(string id, Salesman salesmanPromote)
        {
            bool result = false;
            Uri uri = new Uri($"https://localhost:44337/api/district/" + id + "/PromotePrimarySalesMan");
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(_userName, _password);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var response = client.UploadString(uri,
                        WebRequestMethods.Http.Put,
                        JsonConvert.SerializeObject(salesmanPromote));

                    //TODO ALTER LATER
                    if (response != null)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
