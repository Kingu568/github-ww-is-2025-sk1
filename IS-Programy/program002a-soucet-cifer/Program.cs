namespace program002a_soucet_cifer;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Zadejte číslo: ");
        int number = int.Parse(Console.ReadLine()); // inputs an int
        int sum = 0;
        int prod = 1;

         if (number == 0) //Checks for the case of the number being 0 (needed because of the product)
         {
             Console.WriteLine($"Součet cifer je 0");
             Console.WriteLine($"Součin cifer je 0");
            }
         else
        {
            int temp = number;
            while (temp > 0)
            {
                sum += temp % 10; // modulo 10, returns remainder (the last digit) and adds to the sum
                prod *= temp % 10; //same just for the prouct 
                temp /= 10; // divides by 10 to move to the next digit
            }

            Console.WriteLine($"Součet cifer je {sum}");
            Console.WriteLine($"Součin cifer je {prod}");
        }
        neciselne(number); // Another way of doing things... 

    }
    static void neciselne(int number)
    {
        

        int sum = 0;
        int prod = 1;
        if (number == 0) //checks if number isnt 0 because then prod cant be 1
        {
            Console.WriteLine($"Součet cifer je 0");
            Console.WriteLine($"Součin cifer je 0");
        }
        else
        {
            string fullNum = number.ToString(); // I could also get a new string input but this is faster 
            foreach (char character in fullNum) // Takes every character from string
            {
                int num = (int)char.GetNumericValue(character); // Converts it into an int
                sum += num; //adds
                prod *= num; //adds
            }
            Console.WriteLine($"Součet cifer neciselne je {sum}");
            Console.WriteLine($"Součin cifer neciselne je {prod}");
        }
        
    }
}
