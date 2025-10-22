string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("***** Seřazení dvou čísel *****");
    Console.WriteLine("****************************");
    Console.WriteLine("******* Walter Wolf ********");
    Console.WriteLine("****************************");
    Console.WriteLine();

    // Vstup hodnoty do programu - špatně řešený
    //Console.Write("Zadejte první číslo řady: ");
    //int first = int.Parse(Console.ReadLine());

    //Vstup hodnoty do programu - řešený správně
    Console.Write("Zadejte hodnotu (celé číslo): ");
    int a;
    while (!int.TryParse(Console.ReadLine(), out a))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte druhou hodnotu (celé číslo): ");
    int b;
    while (!int.TryParse(Console.ReadLine(), out b))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }

    if (a > b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    Console.WriteLine("a = " + a);
    Console.WriteLine("b = " + b);



    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}