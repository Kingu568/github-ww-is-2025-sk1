//dotnet new console -o program001-vypis-rady
string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("***** Název programu *****");
    Console.WriteLine("****************************");
    Console.WriteLine("******* Walter Wolf ********");
    Console.WriteLine("****************************");
    Console.WriteLine();

    // Vstup hodnoty do programu - špatně řešený
    //Console.Write("Zadejte první číslo řady: ");
    //int first = int.Parse(Console.ReadLine());

    Console.Write("Zadejte přesnost (např. 0,0001): ");
    double lenght;

    while (!double.TryParse(Console.ReadLine(), out lenght))
    {
        Console.Write("Nezadali jste číslo. Zadejte hodnotu znovu: ");
    }


    double denominator = 1.0;
    double quarterPi = 1.0;
    double positive = 1.0;

    while ((1.0 / denominator) >= lenght)
    {
        denominator = denominator + 2;
        positive = -positive;
        quarterPi = quarterPi + positive * (1.0 / denominator);
    }

    double pi = 4.0 * quarterPi;

    Console.WriteLine();
    Console.WriteLine("Vypočtená hodnota PI je "+ pi);

    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();
}