///
/// Lab 4 and 5
/// Melanie Magno
/// pulling a get request from an API
/// 2/21/2024
///
using lab5;

//have to create a new instance of an api
AmiiboAPI api = new AmiiboAPI();
//setting a bool here to be able to switch out of the switch statement below easily
bool getOut = false;

while (!getOut)
{
    Console.WriteLine("do you want to: \n\t1. print a list of the amiibos \n\t2. print a varying number of amiibos based on its name?\n\t3. Exit");
    string answer = Console.ReadLine();
    switch (answer)
    {
        //if user wants to print list of amiibos
        case "1":
            Amiibo[] response = await api.GetAmiiboNames();
            AmiiboAPI.PrintAmiibo(response);
            break;
        //prints list of amiibos based on name given by user
        case "2": 
            Console.WriteLine("what amiibo do you want to see?");
            string value = Console.ReadLine().ToLower();
            Amiibo[] array = await api.GetAmiiboInfoBasedOnName(value);
            AmiiboAPI.PrintAmiibo(array);
            break;
        //exits the loop
        case "3":
            getOut=true;
            break;
        //another name based amiibo response/not working just yet
        case "4":
            Console.WriteLine("what amiibo do you want to see?");
            string value2 = Console.ReadLine().ToLower();
            Amiibo responseWithName2 = await api.GetAmiiboInfoBasedName(value2);
            
            Console.WriteLine(responseWithName2);
            break;
        //finds amiibo based on id value/also not working just yet
        case "5":
            Console.WriteLine("What ID do you want to look up?");
            string id = Console.ReadLine();
            var ami = await api.GetAmiiboInfoBasedOnID(id);
            AmiiboAPI.PrintAmiibo(ami);
            break;
        default:
            Console.WriteLine("try again");
            break;
    }
}