///
/// Lab 4 and 5
/// Melanie Magno
/// pulling a get request from an API
/// 2/21/2024
///




using lab5;
AmiiboAPI api = new AmiiboAPI();

Console.WriteLine("do you want to: \n1. print a list of the amiibos \n2. print a single amiibo based on its' name?");
string answer = Console.ReadLine();
switch(answer)
{
    //if user wants to print list of amiibos
    case "1":
        HttpResponseMessage response = await api.GetAmiiboNames();

        //should use if(response?.IsSuccessStatusCode) in case the request isnt successful
        var list = await response.Content.ReadAsStringAsync();
        Console.WriteLine(list);
        break;
    case "2":
        Console.WriteLine("what amiibo do you want to see?");
        string value = Console.ReadLine().ToLower();
        HttpResponseMessage responseWithName = await api.GetAmiiboInfoBasedOnName("name", value);
        var amiibo = await responseWithName.Content.ReadAsStringAsync();
        Console.WriteLine(amiibo);
        break;
    default:
        break;
}    