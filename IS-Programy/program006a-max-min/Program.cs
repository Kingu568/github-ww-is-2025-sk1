using System.Globalization;

string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("********************************");
    Console.WriteLine("Generátor pseudo-náhodných čísel");
    Console.WriteLine("*********** Part 2 *************");
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

    int pos = 0;
    int neg = 0;
    int zeros = 0;

    int even = 0;
    int odd = 0;

    List<int> indexes = new List<int>();

    Random rand = new Random();
    int[] randoms = new int[range];
    for (int i = 0; i < range; i++)
    {
        randoms[i] = rand.Next(min, max + 1);
        switch (randoms[i])
        {
            case > 0:
                pos++;
                break;
            case < 0:
                neg++;
                break;
            case 0:
                zeros++;
                break;
        }
        if ((randoms[i] % 2) == 1) odd++;
        else even++;
        

    }

    for (int i = 0; i < randoms.Length - 1; i++)
    {
        Console.Write(randoms[i] + ", ");
    }
    Console.Write(randoms.Last());
    Console.WriteLine();

    Console.WriteLine("Maximální hodnota je: "+randoms.Max());
    for (int i = 0; i < randoms.Length; i++)
    {
        if (randoms[i] == randoms.Max()) indexes.Add(i);
    }
    Console.WriteLine("Kterých/á je "+ indexes.Count() +" a jsou/je na indexech/u: ");
    for (int i = 0; i < indexes.Count()- 1; i++)
    {
        Console.Write(indexes[i] + ", ");
    }
    Console.Write(indexes.Last());
    Console.WriteLine();
    indexes.Clear();
    
    Console.WriteLine("Minimální hodnota je: "+randoms.Min());
    for (int i = 0; i < randoms.Length; i++)
    {
        if (randoms[i] == randoms.Min()) indexes.Add(i);
    }
    Console.WriteLine("Kterých/á je "+ indexes.Count() +" a jsou/je na indexech/u: ");
    for (int i = 0; i < indexes.Count()- 1; i++)
    {
        Console.Write(indexes[i] + ", ");
    }
    Console.Write(indexes.Last());
    Console.WriteLine();

    Console.WriteLine("Kladných čísel bylo: " + pos);
    Console.WriteLine("Záporných čísel bylo: " + neg);
    Console.WriteLine("Nul bylo: " + zeros);

    Console.WriteLine();
    Console.WriteLine("Sudých čísel bylo: " + even);
    Console.WriteLine("Lichých čísel bylo: " + odd);
    Console.WriteLine();
    Console.WriteLine("Přesýpací hodiny jen tak pro radost: ");
    // horní část (včetně středu)
    for (int i = 0; i < randoms.Max() / 2 + randoms.Max() % 2; i++)
    {
        for (int s = 0; s < i; s++)
            Console.Write(" "); 

        for (int h = 0; h < randoms.Max() - 2 * i; h++)
            Console.Write("*"); 

        Console.WriteLine();
    }

    // dolní část
    for (int i = randoms.Max() / 2 - 1; i >= 0; i--)
    {
        for (int s = 0; s < i; s++)
            Console.Write(" ");

        for (int h = 0; h < randoms.Max() - 2 * i; h++)
            Console.Write("*");

        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}