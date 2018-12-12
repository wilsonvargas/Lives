using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItemsShop.Mobile.Services
{
    public class HttpClientService
    {
        public static HttpClientService Instance
        {
            get
            {
                return instance;
            }
        }

        private static readonly HttpClientService instance = new HttpClientService();
        private HttpClient client;

        public async Task<HttpResponseMessage> GetAsync(string api)
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(api);
            return response;
        }

        private HttpClient GetClient()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://itemshop.azurewebsites.net");
            }
            return client;
        }
    }
}
