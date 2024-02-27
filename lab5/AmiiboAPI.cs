﻿using System;
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
        public async Task<Amiibo[]> GetAmiiboNames()
        {
            HttpResponseMessage resp = await httpClient.GetAsync("https://www.amiiboapi.com/api/amiibo/");
            Amiibo[] amis = null;;

            if (resp.IsSuccessStatusCode)
            {
                var values = await resp.Content.ReadFromJsonAsync<AmiiboArray>();
                amis = values.Amiibo;
            }
            return amis;
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
        public static void PrintAmiibo(Amiibo[] ami)
        {
            foreach (Amiibo amiibo in ami)
            {
                Console.WriteLine($"\tName = {amiibo.name}");
            }
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
    }
}
