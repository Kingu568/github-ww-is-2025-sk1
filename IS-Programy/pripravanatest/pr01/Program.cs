
using System.Buffers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Security;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Xml.Schema;

string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("***** Název programu *****");
    Console.WriteLine("****************************");
    Console.WriteLine("******* Walter Wolf ********");
    Console.WriteLine("****************************");
    Console.WriteLine();

    // Vstup hodnoty do programu - špatně řešený
    //Console.Write("Zadejte první číslo řady: ");
    //int first = int.Parse(Console.ReadLine());

    //Vstup hodnoty do programu - řešený správně
    Console.Write("Zadejte počet prvků (celé číslo): ");
    int n;
    while (!int.TryParse(Console.ReadLine(), out n))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
    Console.Write("Zadejte spodní mez (celé číslo): ");
    int sm;
    while (!int.TryParse(Console.ReadLine(), out sm))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }
        Console.Write("Zadejte horní mez (celé číslo): ");
    int hm;
    while (!int.TryParse(Console.ReadLine(), out hm))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte hodnotu znovu: ");
    }

    int[] pole = new int[n];
    int max;
    int min;
    Random rand = new Random();
    for (int i = 0; i < n; i++)
    {
        pole[i] = rand.Next(sm, hm + 1);
    }
    //Vypis pole
    for (int i = 0; i<n-1;i++)
    {
        Console.Write(pole[i] + ", ");
    }
    Console.WriteLine(pole[n-1]);
    //Max a Min
    min = pole[0];
    max = pole[0];
    for(int i = 0; i < n; i++)
    {
        if(pole[i] < min) min = pole[i];
        if (pole[i] > max) max = pole[i];
    }
    Console.Write("Maximální hodnota je: " + max + " Na pozicích:");
    for(int i = 0; i < n; i++)
    {
        if (pole[i] == max) Console.Write(" " + i);
    }
    Console.WriteLine();
    Console.Write("Minimální hodnota je: " + min + " Na pozicích:");
    for(int i = 0; i < n; i++)
    {
        if (pole[i] == min) Console.Write(" " + i);
    }


    int temp = 0;
    for(int i = 0; i < n-1; i++)
    {
        for (int j = 0; j<n-1-i;j++)
        if (pole[j] < pole[j + 1])
        {
            temp = pole[j];
            pole[j] = pole[j+1];
            pole [j+1] = temp;
        }
    }
    Console.WriteLine();

    for (int i = 0; i<n-1;i++)
    {
        Console.Write(pole[i] + ", ");
    }
    Console.WriteLine(pole[n-1]);
    double median;
    if (n % 2 == 1)
    {
        median = pole[n / 2];
    }
    else 
    {
        median = (pole[n / 2 - 1] + pole[n / 2]) / 2.0;
    }
    
    for(int i = 0; i < n - 1; n++)
    {
        if (pole[i] <max)
        {
            break;
        }
    }

    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();
    
    
}