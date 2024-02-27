using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lab5
{
    public class AmiiboAPI
    {
        HttpClient httpClient = new HttpClient();

        /// <summary>
        /// gets the response from the public api
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAmiiboNames()
        {
            HttpResponseMessage resp = await httpClient.GetAsync("https://www.amiiboapi.com/api/amiibo/");

            return resp;
        }

        /// <summary>
        /// another get request for the amiibo api
        /// </summary>
        /// <param name="value">this is the name of the amiibo the user wants to see</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAmiiboInfoBasedOnName(string value)
        {
            HttpResponseMessage resp = await httpClient.GetAsync($"https://www.amiiboapi.com/api/amiibo/?name={value}");
            //checking to see what the message is
            Console.WriteLine(resp.ToString());
            return resp;
        }

        public async Task<Amiibo> GetAmiiboInfoBasedName(string value)
        {
            var resp = await httpClient.GetFromJsonAsync<JsonElement>($"https://www.amiiboapi.com/api/amiibo/?name={value}");

            var array = resp.GetProperty("amiibo");
            var firstItem = array[0];
            var name = firstItem.GetProperty("name").GetString();
            var image = firstItem.GetProperty("image").GetString();

            return new Amiibo
            {
                name = name,
                image = image
            };
        }
    }
}
