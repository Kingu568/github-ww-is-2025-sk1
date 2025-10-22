string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("** Pravouhly Trojuhelnik ***");
    Console.WriteLine("****************************");
    Console.WriteLine("******* Walter Wolf ********");
    Console.WriteLine("****************************");
    Console.WriteLine();

    // Vstup hodnoty do programu - špatně řešený
    //Console.Write("Zadejte první číslo řady: ");
    //int first = int.Parse(Console.ReadLine());

    //Vstup hodnoty do programu - řešený správně
    
    Console.Write("Lenght: ");
    int lenght;
    while (!int.TryParse(Console.ReadLine(), out lenght))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }

    for (int i = 1; i <= lenght; i++)
    {
        for (int j = 0; j < i; j++) Console.Write("* ");
        Console.WriteLine();
        
    }



    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}