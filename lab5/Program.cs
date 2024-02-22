///
/// Lab 4 and 5
/// Melanie Magno
/// pulling a get request from an API
/// 2/21/2024
///
using lab5;

AmiiboAPI api = new AmiiboAPI();
bool getOut = false;

while (!getOut)
{
    Console.WriteLine("do you want to: \n\t1. print a list of the amiibos \n\t2. print a single amiibo based on its' name?\n\t3. Exit");
    string answer = Console.ReadLine();
    switch (answer)
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
            HttpResponseMessage responseWithName = await api.GetAmiiboInfoBasedOnName(value);
            var amiibo = await responseWithName.Content.ReadAsStringAsync();
            Console.WriteLine(amiibo);
            break;
        case "3":
            getOut=true;
            break;
        default:
            Console.WriteLine("try again");
            break;
    }
}