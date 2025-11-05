using System.Globalization;

string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("********************************");
    Console.WriteLine("Generátor pseudo-náhodných čísel");
    Console.WriteLine("********************************");
    Console.WriteLine("********* Walter Wolf **********");
    Console.WriteLine("********************************");
    Console.WriteLine();

    // Vstup hodnoty do programu - špatně řešený
    //Console.Write("Zadejte první číslo řady: ");
    //int first = int.Parse(Console.ReadLine());

    //Vstup hodnoty do programu - řešený správně
    Console.Write("Zadejte počet čísel (celé číslo): ");
    int range;
    while (!int.TryParse(Console.ReadLine(), out range))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte spodní mez (celé číslo): ");
    int min;
    while (!int.TryParse(Console.ReadLine(), out min))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte horní mez (celé číslo): ");
    int max;
    while (!int.TryParse(Console.ReadLine(), out max) || max <= min)
    {
        Console.Write("Nezadali jste celé číslo nebo je číslo menší/rovná se spodní mezi. Zadejte hodnotu znovu: ");
    }
    
    Random rand = new Random();
    int[] randoms = new int[range];
    for (int i = 0; i < range; i++)
    {
        randoms[i] = rand.Next(min, max + 1);
    }

    for (int j = 0; j < randoms.Length-1; j++)
    {
        Console.Write(randoms[j] + ", ");
    }
    Console.Write(randoms.Last());


    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}