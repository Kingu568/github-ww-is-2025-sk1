using System.Globalization;
using System.Linq.Expressions;

string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("********************************");
    Console.WriteLine("******** Bubble Sort 2 *********");
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

    int pos = 0;
    int neg = 0;
    int zeros = 0;

    int even = 0;
    int odd = 0;
    int second;
    int changes = 0;
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

    for (int j = 0; j < randoms.Length-1; j++)
    {
        Console.Write(randoms[j] + ", ");
    }
    Console.Write(randoms.Last());
    Console.WriteLine();
    Console.WriteLine("Kladných čísel bylo: " + pos);
    Console.WriteLine("Záporných čísel bylo: " + neg);
    Console.WriteLine("Nul bylo: " + zeros);
    Console.WriteLine();
    Console.WriteLine("Sudých čísel bylo: " + even);
    Console.WriteLine("Lichých čísel bylo: " + odd);

    for (int i = 0; i < randoms.Length - 1; i++)
    {
        for (int j = 0; j < randoms.Length - 1 - i; j++)
        {
            if (randoms[j] < randoms[j + 1])
            {
                int temp = randoms[j];
                randoms[j] = randoms[j + 1];
                randoms[j + 1] = temp;
                changes++;
            }
        }
    }
    Console.WriteLine("Seřazený list pseudonáhodných čísel pomocí bubble sort :");
    for(int j = 0; j < randoms.Length-1; j++)
    {
        Console.Write(randoms[j] + ", ");
    }
    Console.Write(randoms.Last());
    Console.WriteLine();
    second = randoms[0];
    int x = 1;
    while (second == randoms[0])
    {
        second = randoms[x];
        x++;
    }
    Console.WriteLine("Druhé největší číslo je " + second);
    

    if (second < 1)
    {
        Console.WriteLine();
    }
    else if (second == 1) Console.WriteLine("*");
    else
    {
        

        for (int i = 0; i < second; i++)
            Console.Write("*");
        Console.WriteLine();
        for (int i = 0; i < second; i++)
            Console.Write("*");
        Console.WriteLine();

        for (int i = 0; i < second - 4; i++)
        {
            Console.Write("*");              
            for (int j = 0; j < second - 2; j++)
                Console.Write(" ");          
            Console.Write("*");              
            Console.WriteLine();
        }

        
        for (int i = 0; i < second; i++)
            Console.Write("*");
        Console.WriteLine();
        for (int i = 0; i < second; i++)
            Console.Write("*");
        Console.WriteLine();
    }


    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();


}