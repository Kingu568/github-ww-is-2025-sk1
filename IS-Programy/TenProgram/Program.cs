using System.Collections;
using System.Text.Json;

namespace TenProgram
{
    class Program
    {
        const string DATA_FILE = "data.json";
        const string STATS_FILE = "statistics.json";

        static void Main()
        {
            List<Item> items = LoadItems();
            Statistics stats = LoadStatistics();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("****************************");
                Console.WriteLine("***** FFXIV Market Log *****");
                Console.WriteLine("****************************");
                Console.WriteLine("******* Walter Wolf ********");
                Console.WriteLine("****************************");
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1 - Přidat item");
                Console.WriteLine("2 - Vypsat inventář");
                Console.WriteLine("3 - Upravit item");
                Console.WriteLine("4 - Prodat item");
                Console.WriteLine("5 - Statistiky");
                Console.WriteLine("6 - Smazat item");
                Console.WriteLine("0 - Konec");
                Console.Write("Volba: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem(items);
                        SaveItems(items);
                        break;

                    case "2":
                        PrintItems(items);
                        Console.ReadLine();
                        break;
                    case "3":
                        EditItem(items);
                        SaveItems(items);
                        break;
                    case "4":
                        SellItem(items, stats);
                        SaveItems(items);
                        SaveStatistics(stats);
                        break;
                    case "5":
                        PrintStatistics(stats);
                        Console.ReadLine();
                        break;
                    case "6":
                        RemoveItem(items);
                        SaveItems(items);
                        break;
                    case "0":
                        return;
                }
            }
        }

        static void AddItem(List<Item> items)
        {
            Console.Write("Název: ");
            string name = Console.ReadLine();

            Console.Write("Cena za kus: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Množství: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("HQ? (y/n): ");
            bool isHQ = Console.ReadLine().ToLower() == "y";

            items.Add(new Item
            {
                Name = name,
                PriceForOne = price,
                Quantity = quantity,
                IsHQ = isHQ
            });
        }

        static void PrintItems(List<Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventář je prázdný.");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                var it = items[i];
                string hq = it.IsHQ ? "HQ" : "NQ";

                Console.WriteLine(
                    $"{i}: {it.Name} | {hq} | {it.Quantity} ks | {it.PriceForOne} Gil/ks  | Celkem: {it.PriceForOne * it.Quantity} Gil"
                );
            }
        }

        static void SellItem(List<Item> items, Statistics stats)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Není co prodávat.");
                return;
            }

            PrintItems(items);
            Console.Write("Index itemu k prodeji: ");
            int index;

            while (!int.TryParse(Console.ReadLine(), out index) || index >= items.Count)
            {
                Console.Write("Nezadali jste celé číslo nebo číslo v rozsahu indexů. Zadejte hodnotu znovu: ");
            }

            Item sold = items[index];
            decimal profit = sold.PriceForOne * sold.Quantity;

            stats.TotalItems += sold.Quantity;
            stats.TotalProfit += profit;

            if (sold.IsHQ)
                stats.HQItemProfit += profit;
            else
                stats.NormalItemProfit += profit;

            items.RemoveAt(index);

            Console.WriteLine($"Prodáno za {profit} Gil");
        }
        static void RemoveItem(List<Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Není co mazat.");
                return;
            }

            PrintItems(items);
            Console.Write("Index itemu k smazaní: ");
            int index;

            while (!int.TryParse(Console.ReadLine(), out index) || index >= items.Count)
            {
                Console.Write("Nezadali jste celé číslo nebo číslo v rozsahu indexů. Zadejte hodnotu znovu: ");
            }

            items.RemoveAt(index);
            Console.WriteLine($"Item smazán.");
        }


        static void PrintStatistics(Statistics stats)
        {
            Console.WriteLine("\n--- STATISTIKY ---");
            Console.WriteLine($"Prodáno kusů: {stats.TotalItems}");
            Console.WriteLine($"Celkový zisk: {stats.TotalProfit} Gil");
            Console.WriteLine($"Normal zisk: {stats.NormalItemProfit} Gil");
            Console.WriteLine($"HQ zisk: {stats.HQItemProfit} Gil");
        }


        static List<Item> LoadItems()
        {
            if (!File.Exists(DATA_FILE))
                return new List<Item>();

            return JsonSerializer.Deserialize<List<Item>>(
                File.ReadAllText(DATA_FILE)
            );
        }

        static void SaveItems(List<Item> items)
        {
            File.WriteAllText(
                DATA_FILE,
                JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true })
            );
        }

        static Statistics LoadStatistics()
        {
            if (!File.Exists(STATS_FILE))
                return new Statistics();

            return JsonSerializer.Deserialize<Statistics>(
                File.ReadAllText(STATS_FILE)
            );
        }

        static void SaveStatistics(Statistics stats)
        {
            File.WriteAllText(
                STATS_FILE,
                JsonSerializer.Serialize(stats, new JsonSerializerOptions { WriteIndented = true })
            );
        }
        static void EditItem(List<Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventář je prázdný.");
                return;
            }

            PrintItems(items);
            Console.Write("Index itemu k úpravě: ");
            int index;

            while (!int.TryParse(Console.ReadLine(), out index) || index >= items.Count)
            {
                Console.Write("Nezadali jste celé číslo nebo číslo v rozsahu indexů. Zadejte hodnotu znovu: ");
            }

            Item item = items[index];

            Console.WriteLine("Nech prázdné = beze změny");

            Console.Write($"Název ({item.Name}): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                item.Name = input;

            Console.Write($"Cena za kus ({item.PriceForOne}): ");
            input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal price))
                item.PriceForOne = price;

            Console.Write($"Množství ({item.Quantity}): ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int qty))
                item.Quantity = qty;

            Console.Write($"HQ ({(item.IsHQ ? "y" : "n")}): ");
            input = Console.ReadLine().ToLower();
            if (input == "y") item.IsHQ = true;
            else if (input == "n") item.IsHQ = false;

            Console.WriteLine("Item upraven.");
        }

    }
}
