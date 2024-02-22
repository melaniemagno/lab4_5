using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab5
{
    public class AmiiboAPI
    {
        HttpClient httpClient = new HttpClient();

        //public AmiiboAPI()
        //{
        //    httpClient = new HttpClient();
        //}

        public async Task<HttpResponseMessage> GetAmiiboNames()
        {
            HttpResponseMessage resp = await httpClient.GetAsync("https://www.amiiboapi.com/api/amiibo/");

            return resp;
        }

        public async Task<HttpResponseMessage> GetAmiiboInfoBasedOnName(string name, string value)
        {
            HttpResponseMessage resp = await httpClient.GetAsync($"https://www.amiiboapi.com/api/amiibo/?{name}={value}");

            return resp;
        }
    }
}
