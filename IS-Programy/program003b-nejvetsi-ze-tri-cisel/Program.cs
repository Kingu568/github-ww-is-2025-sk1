string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("**** Největší z 3 čísel ****");
    Console.WriteLine("****************************");
    Console.WriteLine("******* Walter Wolf ********");
    Console.WriteLine("****************************");
    Console.WriteLine();

    // Vstup hodnoty do programu - špatně řešený
    //Console.Write("Zadejte první číslo řady: ");
    //int first = int.Parse(Console.ReadLine());

    //Vstup hodnoty do programu - řešený správně
    Console.Write("Zadejte hodnotu a (celé číslo): ");
    int a;
    while (!int.TryParse(Console.ReadLine(), out a))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte hodnotu b (celé číslo): ");
    int b;
    while (!int.TryParse(Console.ReadLine(), out b))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte hodnotu c (celé číslo): ");
    int c;
    while (!int.TryParse(Console.ReadLine(), out c))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }

    if (a > b)
    {
        if (a > c) Console.WriteLine("Největší je a = " + a);
    }
    else if (b > c)
    {
        Console.WriteLine("Největší je b = " + b);
    }
    else Console.WriteLine("Největší je c = " + c);


        Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}