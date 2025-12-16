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
        Console.Write("Zadejte počet intervalů (celé číslo): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > (max - min))
        {
            Console.Write("Nezadali jste celé číslo nebo počet intervalů je větší než velikost intervalu. Zadejte hodnotu znovu: ");
        }

        int pos = 0;
        int neg = 0;
        int zeros = 0;

        int even = 0;
        int odd = 0;

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

        int interval = (max - min) / n;
        int[] borders = new int[n + 1];
        int[] counts = new int[n];
        for (int i = 0; i <= n; i++)
        {
            borders[i] = min + i * interval;
        }
        borders[n] = max;

        foreach (int x in randoms)
        {
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    if (x >= borders[i] && x <= borders[i + 1])
                        counts[i]++;
                }
                else
                {
                    if (x >= borders[i] && x < borders[i + 1])
                        counts[i]++;
                }
            }
        }
        for(int x = 0; x < counts.Length-1;x++)
        {
        Console.WriteLine("Počet čísel v intervalu <"+borders[x]+" - "+borders[x+1]+") je "+counts[x]);
        }
        Console.WriteLine("Počet čísel v intervalu <"+borders[n-1]+" - "+borders[n]+"> je "+counts[n-1]);


        Console.WriteLine();
        Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
        again = Console.ReadLine();


    }