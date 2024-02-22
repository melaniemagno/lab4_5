




using lab5;
AmiiboAPI api = new AmiiboAPI();

HttpResponseMessage response = await api.GetAmiiboNames();

string list = await response.Content.ReadAsStringAsync();
Console.WriteLine(list);
