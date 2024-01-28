using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using prac;

namespace prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] array1 = new Student[10];

            int count1 = 0;
            while (true)
            {
                string opt = mainmenu();
                if (opt == "1")
                {

                    string isplaced = "";
                    do
                    {
                        array1[count1] = Add();
                        count1++;
                        Console.Write("If you want to add another record press 1 otherwise 0: ");
                        isplaced = Console.ReadLine();
                    } while (isplaced == "1");

                }
                else if (opt == "2")
                {
                    Show(array1, ref count1);

                }
                else if (opt == "3")
                {
                   
                    string isplaced = "";
                    do
                    {
                        string nam;
                        float cal = 0;
                        Console.Write("\t\t\tEnter Student's Name: ");
                        nam = Console.ReadLine();
                        cal = aggregate(array1, ref count1, ref nam, cal);
                        Console.WriteLine("Aggregate of " + nam + " is " + cal);
                        Console.Write("If you want to find out another aggregate press 1 otherwise 0: ");
                        isplaced = Console.ReadLine();
                    } while (isplaced == "1");

                }
                else if (opt == "4")
                {
                    string topper = TopStudent(array1, ref count1);
                    Console.WriteLine("Topper is: " + topper);

                }
                else
                {
                    Console.WriteLine("\t\t\t\tInvalid Input!");
                }
            }

        }
        static Student Add()
        {
            Student s1 = new Student();
            Console.Write("Enter Student's Name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Student's Matric Marks: ");
            s1.matricMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter Student's Fsc Marks: ");
            s1.FscMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter Student's Ecat Marks: ");
            s1.ecatMarks = float.Parse(Console.ReadLine());
            return s1;
        }
        static string mainmenu()
        {
            string option = "";
            string[] array = { "Add Student", "Show Students", "Calculate Aggregate", "Top Student" };
            for (int x = 0; x < 4; x++)
            {
                Console.WriteLine("\t\t\t\t" + (x + 1) + ". " + array[x]);
            }
            Console.Write("\t\tEnter Option: ");
            option = Console.ReadLine();
            return option;
        }
        static void Show(Student[] array, ref int count1)
        {
            if (array != null)
            {
                Console.WriteLine("Name\t\t\tMatric Marks\t\t\tIntermediate Marks\t\t\t\tEcat Marks");

                for (int i = 0; i < count1; i++)
                {
                    if (array[i] != null)
                    {
                        Console.WriteLine(array[i].name + "\t\t\t" + array[i].matricMarks + "\t\t\t\t\t" + array[i].FscMarks + "\t\t\t\t\t" + array[i].ecatMarks);
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tNo Student Record is Placed Yet!");
                    }
                }
            }
            else
            {
                Console.WriteLine("\t\t\tNo Student Record is Placed Yet!");
            }
        }
        static float aggregate(Student[] array, ref int count, ref string nam, float cal)
        {

            for (int x = 0; x < count; x++)
            {
                if (array[x].name == nam)
                {
                    cal = (float)((array[x].matricMarks * 0.2) + (array[x].ecatMarks * 0.4) + (array[x].FscMarks * 0.4));
                    array[x].aggregate = cal;
                    break;
                }
            }
           
            
                Console.WriteLine("No Record Found!");
            
            return cal;
        }
        static string TopStudent(Student[] array, ref int count)
        {
            float largest = array[0].aggregate;
            string name = array[0].name;
            for (int x = 0; x < count; x++)
            {
                if (largest < array[x].aggregate)
                {
                    largest = array[x].aggregate;
                    name = array[x].name;
                }
            }
            return name;
        }
    }
}
