using System;
using System.Collections.Generic;
using System.Linq;

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

    Console.Write("Zadejte počet čísel (celé číslo): ");
    int range;
    while (!int.TryParse(Console.ReadLine(), out range) || range <= 0)
        Console.Write("Neplatný vstup. Zadejte znovu: ");

    Console.Write("Zadejte spodní mez (celé číslo): ");
    int min;
    while (!int.TryParse(Console.ReadLine(), out min))
        Console.Write("Neplatný vstup. Zadejte znovu: ");

    Console.Write("Zadejte horní mez (celé číslo): ");
    int max;
    while (!int.TryParse(Console.ReadLine(), out max) || max <= min)
        Console.Write("Neplatný vstup. Zadejte znovu: ");

    int pos = 0, neg = 0, zeros = 0;
    int even = 0, odd = 0;

    Random rand = new Random();
    int[] randoms = new int[range];

    for (int i = 0; i < range; i++)
    {
        randoms[i] = rand.Next(min, max + 1);

        if (randoms[i] > 0) pos++;
        else if (randoms[i] < 0) neg++;
        else zeros++;

        if (randoms[i] % 2 == 0) even++;
        else odd++;
    }

    Console.WriteLine("\nVygenerovaná čísla:");
    Console.WriteLine(string.Join(", ", randoms));
    Console.WriteLine("-----");

    // MAX a MIN + pozice
    int maximum = randoms[0];
    int minimum = randoms[0];

    for (int i = 1; i < randoms.Length; i++)
    {
        if (randoms[i] > maximum) maximum = randoms[i];
        if (randoms[i] < minimum) minimum = randoms[i];
    }

    Console.Write($"Maximum: {maximum}, pozice: ");
    for (int i = 0; i < randoms.Length; i++)
        if (randoms[i] == maximum)
            Console.Write(i + "; ");
    Console.WriteLine();

    Console.Write($"Minimum: {minimum}, pozice: ");
    for (int i = 0; i < randoms.Length; i++)
        if (randoms[i] == minimum)
            Console.Write(i + "; ");
    Console.WriteLine("\n-----");

    // Skaher sort (výběrové třídění – sestupně)
    for (int i = 0; i < randoms.Length - 1; i++)
    {
        int maxIndex = i;
        for (int j = i + 1; j < randoms.Length; j++)
            if (randoms[j] > randoms[maxIndex])
                maxIndex = j;

        int tmp = randoms[i];
        randoms[i] = randoms[maxIndex];
        randoms[maxIndex] = tmp;
    }

    Console.WriteLine("Pole po seřazení (Skaher sort):");
    Console.WriteLine(string.Join(", ", randoms));
    Console.WriteLine("-----");

    // různé největší hodnoty
    List<int> unique = new List<int>();
    foreach (int x in randoms)
        if (!unique.Contains(x))
            unique.Add(x);

    if (unique.Count >= 4)
    {
        int druhe = unique[1];
        int treti = unique[2];
        int ctvrte = unique[3];

        Console.WriteLine($"Druhé největší číslo: {druhe}");
        Console.WriteLine($"Třetí největší číslo: {treti}");
        Console.WriteLine($"Čtvrté největší číslo: {ctvrte}");
        Console.WriteLine("-----");


        double median;
        if (range % 2 == 1)
            median = randoms[range / 2];
        else
            median = (randoms[range / 2 - 1] + randoms[range / 2]) / 2.0;

        Console.WriteLine($"Medián = {median}");
        Console.WriteLine("-----");

        Console.WriteLine($"Čtvrté největší číslo v binární soustavě:");
    if (ctvrte == 0)
    {
        Console.WriteLine("0");
    }
    else
    {
        int number = Math.Abs(ctvrte);
        int index = 0;

        
        while (number > 0)
        {
            bin[index] = number % 2;   
            number /= 2;
            index++;
        }

        
        if (dec < 0) Console.Write("-");

        for (int i = index - 1; i >= 0; i--)
        {
            Console.Write(bin[i]);
        }
        Console.WriteLine();
    }

        Console.WriteLine("-----");
       
        int vyska = (int)median;
        int sirka = treti;

        Console.WriteLine("Obrazec:");
        for (int i = 0; i < vyska; i++)
        {
            if (i < 2 || i >= vyska - 2)
                Console.WriteLine(" * * ");
            else
                Console.WriteLine(new string('*', sirka * 2));
        }
    }
    else
    {
        Console.WriteLine("Není dost různých čísel pro určení 4. největšího.");
    }

    Console.WriteLine("\nPro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();
}
