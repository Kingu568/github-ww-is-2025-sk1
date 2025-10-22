using System.Formats.Asn1;

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
    Console.Write("Zadejte hodnotu A (celé číslo): ");
    int a;
    while (!int.TryParse(Console.ReadLine(), out a))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte hodnotu B (celé číslo): ");
    int b;
    while (!int.TryParse(Console.ReadLine(), out b))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte hodnotu C (celé číslo): ");
    int c;
    while (!int.TryParse(Console.ReadLine(), out c))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }

    
    if (a == b & b == c) Console.WriteLine("Všechny proměnné jsou stejné a, b, c = " + a);
    else if (a > b)
    {
        if (a > c) Console.WriteLine("Největší je A = " + a);
    }
    else if (b > c)
    {
        if (a == b) Console.WriteLine("Největší je jak A tak B = " + b);
        Console.WriteLine("Největší je b = " + b);
    }
    else if (a == c) Console.WriteLine("Největší je jak A tak C = " + c);
    else if (b == c) Console.WriteLine("Největší je jak B tak C = " + c);
    else Console.WriteLine("Největší je c = " + c);


        Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}