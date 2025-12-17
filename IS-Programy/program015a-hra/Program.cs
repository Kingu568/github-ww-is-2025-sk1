using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random rnd = new Random();
    const int CIL = 4000;

    static void Main()
    {
    string again = "a";
    while (again == "a")
    {
        int hracSkore = 0;
        int cpuSkore = 0;

        Console.WriteLine("=== KCD Kostky (Farkle) ===");

        while (hracSkore < CIL && cpuSkore < CIL)
        {
            Console.WriteLine("\n--- TVŮJ TAH ---");
            Console.WriteLine($"Tvé celkové skóre: {hracSkore}");
            hracSkore += TahHrace(hracSkore);

            if (hracSkore >= CIL) break;

            Console.WriteLine("\n--- TAH SOUPEŘE ---");
            cpuSkore += TahCPU(cpuSkore);
            Console.WriteLine($"Skóre soupeře: {cpuSkore}");
        }

        Console.WriteLine(hracSkore >= CIL ? "\n🎉 Vyhrál jsi!" : "\n💀 Prohrál jsi.");
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();
    }

    static int TahHrace(int aktualniSkore)
    {
        int bodyVKole = 0;
        int kostky = 6;

        while (true)
        {
            int[] hod = HodKostek(kostky);
            Console.WriteLine($"Hod: {string.Join(" ", hod)}");

            int body = SpocitejBody(hod, out int pouzite);
            if (body == 0)
            {
                Console.WriteLine("SMŮLA! Ztrácíš body z kola.");
                return 0;
            }

            bodyVKole += body;
            kostky -= pouzite;
            if (kostky == 0) kostky = 6;

            Console.WriteLine($"Získáno: {body} | V kole: {bodyVKole}");
            
            Console.Write("Pokračovat? (a/n): ");
            if (Console.ReadLine().ToLower() != "a")
                return bodyVKole;
        }
    }

    static int TahCPU(int aktualniSkore)
    {
        int bodyVKole = 0;
        int kostky = 6;

        while (bodyVKole < 500)
        {
            int[] hod = HodKostek(kostky);
            Console.WriteLine($"Soupeř hodil: {string.Join(" ", hod)}");

            int body = SpocitejBody(hod, out int pouzite);

            if (body == 0)
            {
                Console.WriteLine("Soupeř má smůlu.");
                Thread.Sleep(1500);
                return 0;
            }
            

            bodyVKole += body;
            kostky -= pouzite;
            if (kostky == 0) kostky = 6;
        }


        Console.WriteLine($"Soupeř ukládá {bodyVKole} bodů.");
        Thread.Sleep(1500);
        return bodyVKole;
    }

    static int[] HodKostek(int pocet)
    {
        int[] hod = new int[pocet];
        for (int i = 0; i < pocet; i++)
            hod[i] = rnd.Next(1, 7);
        return hod;
    }

    static int SpocitejBody(int[] hod, out int pouzite)
    {
        pouzite = 0;
        int body = 0;

        var skupiny = hod.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        // Trojice a víc
        foreach (var g in skupiny)
        {
            if (g.Value >= 3)
            {
                if (g.Key == 1)
                {
                    body += 1000 * (int)Math.Pow(2, g.Value - 3);
                }
                else
                {
                    body += g.Key * 100 * (g.Value - 2);
                }

                pouzite += g.Value;
            }
        }

        // Jednotky a pětky mimo trojice
        int jednicky = skupiny.ContainsKey(1) ? skupiny[1] % 3 : 0;
        int petky = skupiny.ContainsKey(5) ? skupiny[5] % 3 : 0;

        body += jednicky * 100 + petky * 50;
        pouzite += jednicky + petky;

        return body;
    }
}
}