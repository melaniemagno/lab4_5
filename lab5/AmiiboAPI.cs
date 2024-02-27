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
        /// <returns>amiibo array</returns>
        public async Task<Amiibo[]> GetAmiiboNames()
        {
            //this is the http response message
            HttpResponseMessage resp = await httpClient.GetAsync("https://www.amiiboapi.com/api/amiibo/");

            //create an empty array just in case things go sour
            Amiibo[] array = null;

            //if the http responsemessage is successful in getting through to online api
            if (resp.IsSuccessStatusCode)
            {
                //using var just in case, returns an array of values
                AmiiboArray amiibos = await resp.Content.ReadFromJsonAsync<AmiiboArray>();
                //fill in previously defined array with the amiibos read from the Json list.
                //should automatically create the values of name and image based on the json file
                array = amiibos.Amiibo;
            }
            return array;
        }

        /// <summary>
        /// another get request for the amiibo api that returns a list of amiibos based on the name given by the user
        /// </summary>
        /// <param name="value">this is the name of the amiibo the user wants to see</param>
        /// <returns>Amiibo[]</returns>
        public async Task<Amiibo[]> GetAmiiboInfoBasedOnName(string value)
        {
            HttpResponseMessage resp = await httpClient.GetAsync($"https://www.amiiboapi.com/api/amiibo/?name={value}");
            Amiibo[] array = null;

            //if the http responsemessage is successful in getting through to online api
            if (resp.IsSuccessStatusCode)
            {
                //using var just in case, returns an array of values
                AmiiboArray amiibos = await resp.Content.ReadFromJsonAsync<AmiiboArray>();
                //fill in previously defined array with the amiibos read from the Json list.
                //should automatically create the values of name and image based on the json file
                array = amiibos.Amiibo;
            }
            return array;
        }
        public async Task<Amiibo[]> GetAmiiboInfoBasedOnID(string value)
        {
            Amiibo[] amis = null;
            HttpResponseMessage resp = await httpClient.GetAsync($"https://www.amiiboapi.com/api/amiibo/?id={value}");
            //var parsedInfo = JsonSerializer.Deserialize<Amiibo>(resp.ToString());
            if(resp.IsSuccessStatusCode)
            {
                var values = await resp.Content.ReadFromJsonAsync<AmiiboArray>();
                amis = values.Amiibo;
            }
            return amis;
            //var name = parsedInfo.name;
            //var image = parsedInfo.image;
            //return new Amiibo
            //{ name = name, image = image };
        }
        public async Task<Amiibo> GetAmiiboInfoBasedName(string value)
        {
            Amiibo ami = null;
            HttpResponseMessage resp = await httpClient.GetAsync($"https://www.amiiboapi.com/api/amiibo/?name={value}");
            if (resp.IsSuccessStatusCode)
            {
                ami = await resp.Content.ReadFromJsonAsync<Amiibo>();
            }
            return ami;
        }

        /// <summary>
        /// prints out a list of names of amiibos
        /// </summary>
        /// <param name="ami">an array of amiibos</param>
        public static void PrintAmiibo(Amiibo[] ami)
        {
            List<Amiibo> list = new List<Amiibo>();
            foreach (Amiibo amiibo in ami)
            {
                list.Add(amiibo);
            }
            list.Sort();
            foreach (Amiibo amiibo in list)
            {
                Console.WriteLine($"\t" + amiibo.amiiboSeries + "--------" + amiibo.name );
            }
        }
    }
}
