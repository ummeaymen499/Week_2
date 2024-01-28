using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shop> Thing = new List<Shop>();
            while (true)
            {
                string opt = mainmenu();
                if (opt == "1")
                {

                    string isplaced = "";
                    do
                    {
                        Thing.Add(Add());
                        Console.Write("If you want to add another Product press 1 otherwise 0: ");
                        isplaced = Console.ReadLine();
                    } while (isplaced == "1");

                }
                else if (opt == "2")
                {
                    Show(Thing);
                }
                else if (opt == "3")
                {
                    float result = PriceCalculate(Thing);
                    Console.WriteLine("Price of all products is: " + result);
                }
            }
        }
        static string mainmenu()
        {
            string option = "";
            string[] array = { "Add Product", "Show Product", "Calculate Total Price" };
            for (int x = 0; x < 3; x++)
            {
                Console.WriteLine("\t\t\t\t" + (x + 1) + ". " + array[x]);
            }
            Console.Write("\t\tEnter Option: ");
            option = Console.ReadLine();
            return option;
        }
        static Shop Add()
        {
            Shop s1 = new Shop();
            Console.Write("Enter ID: ");
            s1.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            s1.Name = Console.ReadLine();
            Console.Write("Enter Price: ");
            s1.Price = float.Parse(Console.ReadLine());
            Console.Write("Enter Category: ");
            s1.Category = Console.ReadLine();
            Console.Write("Enter BrandName: ");
            s1.BrandName = Console.ReadLine();
            Console.Write("Enter Country: ");
            s1.Country = Console.ReadLine();
            return s1;
        }
        static void Show(List<Shop> Thing)
        {
            if (Thing != null)
            {
                Console.WriteLine("Name\t\tID\t\tCategory\t\tBrandName\t\tCountry\t\t\tPrice");

                for (int i = 0; i < Thing.Count; i++)
                {
                    if (Thing[i] != null)
                    {
                        Console.WriteLine(Thing[i].Name + "\t\t" + Thing[i].ID + "\t\t" + Thing[i].Category + "\t\t\t" + Thing[i].BrandName + "\t\t\t" + Thing[i].Country + "\t\t\t" + Thing[i].Price);
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tNo Record is Placed Yet!");
                    }
                }
            }
            else
            {
                Console.WriteLine("\t\t\tNo Record is Placed Yet!");
            }
        }
        static float PriceCalculate(List<Shop> List)
        {
            float sum=0;
            for (int x = 0; x < List.Count; x++)
            {
                sum = sum + List[x].Price;
            }
            return sum;
        }
    }
    
}
