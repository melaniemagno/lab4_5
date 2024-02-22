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

        //public async Task GetAmiibo(int id)
        //{
        //    //finding specific amiibo in question
        //    var apiresp = await httpClient.GetFromJsonAsync<JsonElement>($"https://www.amiiboapi.com/api/amiibo/{id}");

            //returning new amiibo with the 2 required properties:
            //name and image
            //leaving image for now as i dont want to mess with it yet
            //new Amiibo
            //{
            //    Name = $"#{id}{apiresp.GetProperty("name")}",
            //    Image = $"https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_01010000-03520902.png"
            //}
        //}
    }
}
