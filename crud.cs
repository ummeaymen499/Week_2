using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opt;
            List<Worker> workers = new List<Worker>();
            string path = "F:\\OOP\\CRUD\\CRUD\\Workers.txt";
            int xA = 34; int yA = 14;
            do
            {

                administrator();
                systemmonitoringtitle();
                opt = systemmonitoringmenu(xA, yA);
                if (opt == "1")
                {
                    DisplayWorkers(workers);
                }
                else if (opt == "2")
                {

                    Console.Clear();
                    Console.WriteLine("                             -------------------------------------------------------------------------------");
                    Console.WriteLine("                                                               ADD WORKERS                                ");
                    Console.WriteLine();
                    Console.WriteLine("                             -------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("\t\t\t\t\t" + "Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("\t\t\t\t\t" + "Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("\t\t\t\t\t" + "Enter Rank: ");
                    string rank = Console.ReadLine();
                    Console.Write("\t\t\t\t\t" + "Enter Skills: ");
                    string skill = Console.ReadLine();
                    Console.Write("\t\t\t\t\t" + "Enter Salary: ");
                    float salary = float.Parse(Console.ReadLine());
                    AddWorkers(name, id, rank, skill, salary, path, workers);
                }
                else if (opt == "3")
                {

                }
                else if (opt == "4")
                {
                    DeleteWorkers(workers,path);
                }
                else if (opt == "5")
                {

                }
                else if (opt == "6")
                {

                }
                else
                {
                    Console.WriteLine("                                 Invalid Choice. Please Try Again...");
                    Console.WriteLine("                                   ");
                    Console.ReadKey();
                    continue;

                }
            } while (opt == "1" || opt == "2" || opt == "3" || opt == "4" || opt == "5");
        }
        static string systemmonitoringmenu(int xA, int yA)
        {
            string option;
            string[] array = { "View Workers", "Add Workers", "Edit Workers", "Delete Workers", "Search Workers", "Exit" };
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(xA, yA);
                Console.WriteLine(i + 1 + ". " + array[i]);
                yA = yA + 1;
            }
            Console.SetCursorPosition(xA, yA);
            Console.Write("Choose Option(1-6): ");
            option = Console.ReadLine();
            return option;
        }
        static void AddWorkers(string name, int id, string rank, string skill, float salary, string path, List<Worker> workers)
        {
            StreamWriter File = new StreamWriter(path, true);
            File.WriteLine(name + ";" + id + ";" + rank + ";" + skill + ";" + salary);
            File.Flush();
            File.Close();
            Console.WriteLine("Congratulations! Worker's Account has been Added successfully...");
            ReadWorkersData(path, workers);
            Console.ReadKey();
        }
        static void ReadWorkersData(string path, List<Worker> workers)
        {

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Worker w = new Worker();
                    w.Name = parseData(record, 1);

                    if (int.TryParse(parseData(record, 2), out int id))
                    {
                        // Parsing successful, assign the value
                        w.ID = id;
                    }
                    else
                    {
                        // Parsing failed, handle the error or skip this record
                        Console.WriteLine("Error parsing ID for worker. Skipping this record.");
                        continue; // Skip to the next record
                    }

                    w.Rank = parseData(record, 3);
                    w.Skill = parseData(record, 4);

                    if (float.TryParse(parseData(record, 5), out float salary))
                    {
                        // Parsing successful, assign the value
                        w.Salary = salary;
                        workers.Add(w);
                    }
                    else
                    {
                        // Parsing failed, handle the error or skip this record
                        Console.WriteLine("Error parsing salary for worker. Skipping this record.");
                    }
                }

                file.Close();
            }
            else
            {
                Console.SetCursorPosition(40, 21);
                Console.WriteLine("-------------------------------------------------");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("                    No Data Found                ");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("-------------------------------------------------");

            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ';')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void DisplayWorkers(List<Worker> workers)
        {
            Console.Clear();
            Console.WriteLine("                             -------------------------------------------------------------------------------");
            Console.WriteLine("                                                             WORKERS INFORMATION                        ");
            Console.WriteLine();
            Console.WriteLine("                             -------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("\t\t" + "Name" + "\t\t" + "|" + "\t" + "ID" + "\t\t" + "|" + "\t" + "Rank" + "\t\t" + "|" + "\t" + "Skills" + "\t\t" + "|" + "\t" + "Salary");

            Console.WriteLine(workers.Count);
            if (workers.Count == 0)
            {
                Console.WriteLine("No workers to display.");
            }
            else
            {
                foreach (var worker in workers)
                {
                    Console.WriteLine("\t\t" + worker.Name + "\t\t" + "|" + "\t" + worker.ID + "\t\t" + "|" + "\t" + worker.Rank + "\t\t" + "|" + "\t" + worker.Skill + "\t\t" + "|" + "\t" + worker.Salary);
                }
            }

            Console.ReadKey();
        }
        static void systemmonitoringtitle()
        {
            Console.WriteLine("                                               <<<<      SYSTEM MONITORING     >>>>                      ");
            Console.WriteLine("                                                                                                      ");
        }
        static void administrator()
        {
            Console.Clear();
            Console.WriteLine("                                                                                                                 ");
            Console.WriteLine("                                                                                                                ");
            Console.WriteLine("                                                  |  |                                                         ");
            Console.WriteLine("                                         ******   |/\\|elcome to IndustriaSync Hub     ******                                                                              ");
            Console.WriteLine("                                                                                                                 ");
            Console.WriteLine("                            ------------------------------------------------------------------------------                                    ");
            Console.WriteLine("                                                           Administrator Menu                                        ");
            Console.WriteLine("                            ------------------------------------------------------------------------------                                    ");
            Console.WriteLine("                                                                                                                        ");
        }
        static void DeleteWorkers(List<Worker> workers,string path)
        {
            Console.Clear();
            Console.WriteLine("                             -------------------------------------------------------------------------------");
            Console.WriteLine("                                                             DELETE WORKERS                        ");
            Console.WriteLine();
            Console.WriteLine("                             -------------------------------------------------------------------------------");
            Console.WriteLine();
            int id;
            Console.Write("\t\t\t\t" + "Enter Employee ID: ");
            id = int.Parse(Console.ReadLine());
            for (int x = 0; x < workers.Count; x++)
            {
                if (id == workers[x].ID)
                {
                    workers.RemoveAt(x);
                    Console.WriteLine("\t\t\t" + "Deleted Successfully!");
                    ReadWorkersData(path, workers);
                }
                else
                {
                    Console.WriteLine("\t\t\t" + "Employee not found!");
                }
            }
            Console.ReadKey();

        }
    }
}

