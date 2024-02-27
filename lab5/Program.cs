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
    Console.WriteLine("do you want to: \n\t1. print a list of the amiibos \n\t2. print a single amiibo based on its name?\n\t3. Exit");
    string answer = Console.ReadLine();
    switch (answer)
    {
        //if user wants to print list of amiibos
        case "1":
            Amiibo[] response = await api.GetAmiiboNames();

            //should use if(response?.IsSuccessStatusCode) in case the request isnt successful
            Console.WriteLine(response);
            if (response != null)
            {
                foreach (var item in response)
                { Console.WriteLine(item.name); }
            }
            AmiiboAPI.PrintAmiibo(response);
            break;
        case "2":
            Console.WriteLine("what amiibo do you want to see?");
            string value = Console.ReadLine().ToLower();
            Amiibo[] array = await api.GetAmiiboInfoBasedOnName(value);

            AmiiboAPI.PrintAmiibo(array);
            break;
        case "3":
            getOut=true;
            break;
        case "4":
            Console.WriteLine("what amiibo do you want to see?");
            string value2 = Console.ReadLine().ToLower();
            Amiibo responseWithName2 = await api.GetAmiiboInfoBasedName(value2);
            
            Console.WriteLine(responseWithName2);
            break;
        case "5":
            Console.WriteLine("What ID do you want to look up?");
            string id = Console.ReadLine();

            var ami = await api.GetAmiiboInfoBasedOnID(id);
            if(ami != null)
            { foreach(var item in ami)
                { Console.WriteLine(item.name); } 
            }
            AmiiboAPI.PrintAmiibo(ami);
            break;
        default:
            Console.WriteLine("try again");
            break;
    }
}