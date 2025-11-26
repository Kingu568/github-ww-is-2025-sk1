string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("**** Převod do binární *****");
    Console.WriteLine("****************************");
    Console.WriteLine("******* Walter Wolf ********");
    Console.WriteLine("****************************");
    Console.WriteLine();

    Console.Write("Zadejte číslo (celé číslo): ");
    int dec;
    int[] bin = new int[32];
    while (!int.TryParse(Console.ReadLine(), out dec))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }

    if (dec == 0)
    {
        Console.WriteLine("Binárně: 0");
    }
    else
    {
        int number = Math.Abs(dec);
        int index = 0;

        
        while (number > 0)
        {
            bin[index] = number % 2;   
            number /= 2;
            index++;
        }

        
        if (dec < 0) Console.Write("-");

        Console.Write("Binárně: ");

        for (int i = index - 1; i >= 0; i--)
        {
            Console.Write(bin[i]);
        }
        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();
}