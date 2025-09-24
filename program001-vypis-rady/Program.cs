// See https://aka.ms/new-console-template for more information
namespace program001_vypis_rady;
class Program
{
    static void Main(string[] args)
    {   
        Console.Write("První hodnota: ");
        int first = int.Parse(Console.ReadLine());

        Console.Write("Poslední hodnotu: ");
        int last = int.Parse(Console.ReadLine());

        Console.Write("Velikost kroku : ");
        int step = int.Parse(Console.ReadLine());

        for (int i = first; i <= last; i += step)
        {
            Console.WriteLine(i);
        }
    }
}
