




using lab5;
AmiiboAPI api = new AmiiboAPI();

HttpResponseMessage response = await api.GetAmiiboNames();

//should use if(response?.IsSuccessStatusCode) in case the request isnt successful
var list = await response.Content.ReadAsStringAsync();
Console.WriteLine(list);
