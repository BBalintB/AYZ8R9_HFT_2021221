using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    class RestService
    {
        HttpClient Client;
        public RestService(string baseUrl)
        {
            Init(baseUrl);
        }

        private void Init(string baseUrl)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));
            try
            {
                Client.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException)
            {
                throw new ArgumentException("Endpoint is not available!");
            }
        }

        public List<T> Get<T>(string endpoint)
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = Client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
            }
            return items;
        }
        public T GetSingle<T>(string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = Client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                    item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            
            return item;
        }

        public void Post<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                Client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }

        public void Delete(int id, string endpoint)
        {
            HttpResponseMessage response =
                Client.DeleteAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }
        public void Put(int id,string choose,string item, string endpoint)
        {
            HttpResponseMessage response =
                Client.PutAsJsonAsync(endpoint+"/"+id.ToString()+"/"+choose,item).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }
    }
}
