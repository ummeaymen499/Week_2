using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MUser> users = new List<MUser>();
            string Path = "F:\\OOP\\LoginSystem\\LoginSystem\\Login.txt";
            int x1 = 30, y1 = 16;
            string opt;
            do
            {
                ReadSignUpData(Path, users);
                Console.Clear();
                title();
                logintitle();
                opt = LoginInterface(x1, y1);
                if (opt == "1")
                {
                    Console.Clear();
                    title();
                    Console.WriteLine( "                                                                                                                 " );
                    Console.WriteLine( "                                               To access the system, Please LOG IN...." );
                    Console.WriteLine( "                            --------------------------------------------------------------------------                                    " );
                    Console.WriteLine( "                                                                                                                     " );
                    Console.WriteLine( "                            --------------------------------------------------------------------------              " );
                    Console.WriteLine( "                                                                                                                      " );
                    Console.SetCursorPosition(50, 13);
                    Console.Write( "<<<<<<<    SIGN IN MENU     >>>>>>>>");
                    Console.SetCursorPosition(30, 16);
                    Console.Write("Enter UserName: ");
                    string n = Console.ReadLine();
                    Console.SetCursorPosition(30, 17);
                    Console.Write("Enter Password: ");
                    string p = Console.ReadLine();
                    Console.SetCursorPosition(30, 18);
                    Console.Write("Sign In as (Administrator, Manager, Customer): ");
                    string r = Console.ReadLine();
                    SignIn(n, p, r, users);
                }
                else if (opt == "2")
                {
                    Console.Clear();
                    title();
                    Console.WriteLine("                                                                                                                 ");
                    Console.WriteLine("                                               To access the system, Please LOG IN....");
                    Console.WriteLine("                            --------------------------------------------------------------------------                                    ");
                    Console.WriteLine("                                                                                                                     ");
                    Console.WriteLine("                            --------------------------------------------------------------------------              ");
                    Console.WriteLine("                                                                                                                      ");
                    Console.SetCursorPosition(50, 13);
                    Console.Write("<<<<<<<    SIGN UP MENU     >>>>>>>>");
                    string UserName, Password, Role;
                    Console.SetCursorPosition(30, 16);
                    Console.Write("Select Username: ");
                    UserName = Console.ReadLine();
                    Console.SetCursorPosition(30, 17);
                    Console.Write("Select Password: ");
                    Password = Console.ReadLine();
                    Console.SetCursorPosition(30, 18);
                    Console.Write("Sign Up as (Administrator, Manager, Customer): ");
                    Role = Console.ReadLine();
                    if (Role != "Administrator" && Role != "administrator" && Role != "Manager" && Role != "manager" && Role != "Customer" && Role != "customer")
                    {
                        Console.SetCursorPosition(35, 20);
                        Console.WriteLine("Invalid User Role Entered! Please choose a valid role...");
                        Console.ReadKey();
                    }
                    else 
                    {
                        SignUp(Path, UserName, Password, Role);
                    }
                    
                }
                else if (opt == "3")
                {
                    Console.WriteLine( "                                                                               " );
                    Console.WriteLine( "                                         Are you sure you want to exit!" );
                    Console.WriteLine();
                    Console.WriteLine( "                                   YES                   or                 NO" );
                    Console.WriteLine();
                    string choice;
                    Console.Write( "                                Your Choice: ");
                    choice =Console.ReadLine();
                    if (choice == "YES" || choice == "yes")
                    {
                        Console.Clear();
                        Console.SetCursorPosition(50, 0);
                        Console.WriteLine( "Exiting IndustriaSync Hub...GoodBye!" );
                        Environment.Exit(0);
                    }
                    else if (choice == "NO" || choice == "no")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine( "                                 Invalid Choice. Please Try Again..." );
                        Console.WriteLine( "                                                                                      " );
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.SetCursorPosition(x1 + 5, y1 + 5);
                    Console.WriteLine("                                                                                         ");
                    Console.WriteLine("                                Invalid Input! Please Try Again...");
                    Console.WriteLine("                                                                                         ");
                    Console.ReadKey();
                }
            }
            while (opt == "1" || opt == "2" || opt == "3");


        }
        static string LoginInterface(int x1, int y1)
            {
                string option = "";
                string[] array = { "Sign In", "Sign Up", "Exit" };
                for (int idx = 0; idx < 3; idx++)
                {
                    Console.SetCursorPosition(x1, y1);
                    Console.Write(idx + 1 + ". " + array[idx]);
                    y1 = y1 + 1;
                }
            Console.SetCursorPosition(x1, y1);
            Console.WriteLine("Choose Option(1-3): ");
            option = Console.ReadLine();
                return option;

            }
            static void SignUp(string path, string name, string pass, string role)
            {
                StreamWriter File = new StreamWriter(path, true);
                File.WriteLine(name + ";" + pass + ";" + role);
                File.Flush();
                File.Close();
            Console.SetCursorPosition(35, 20);
            Console.WriteLine("Congratulations! Your account has been Signed UP successfully...");
            Console.ReadKey();
        }
            static void ReadSignUpData(string path, List<MUser> users)
            {
                
                if (File.Exists(path))
                {
                    StreamReader file = new StreamReader(path);
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        MUser info = new MUser();
                        info.UserName = parseData(record, 1);
                        info.Password = parseData(record, 2);
                        info.Role = parseData(record, 3);
                        users.Add(info);
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
            static void SignIn(string name, string pass,string role, List<MUser> users)
            {
                bool flag = false;
                for (int x = 0; x < users.Count; x++)
                {
                    if (name == users[x].UserName && pass == users[x].Password && role == users[x].Role)
                    {
                    Console.SetCursorPosition(35, 20);
                    Console.WriteLine( "Congratulations! Your account has been logged IN successfully..." );
                    flag = true;
                    }
                }
                if (flag == false)
                {
                Console.SetCursorPosition(35, 20);
                Console.WriteLine("Invalid Credentials! Please Try Again...");
            }
                Console.ReadKey();
            }
            static void title()
            {
            Console.WriteLine("                       _____           _           _        _        _____                    _    _       _     ");
            Console.WriteLine("                      |_   _|         | |         | |      (_)      / ____|                  | |  | |     | |    ");
            Console.WriteLine("                        | |  _ __   __| |_   _ ___| |_ _ __ _  __ _| (___  _   _ _ __   ___  | |__| |_   _| |__  ");
            Console.WriteLine("          ******        | | | '_ \\ / _` | | | / __| __| '__| |/ _` |\\___ \\| | | | '_ \\ / __| |  __  | | | | '_ \\      ******");
            Console.WriteLine("                       _| |_| | | | (_| | |_| \\__ \\ |_| |  | | (_| |____) | |_| | | | | (__  | |  | | |_| | |_) |");
            Console.WriteLine("                      |_____|_| |_|\\__,_|\\__,_|___/\\__|_|  |_|\\__,_|_____/ \\__, |_| |_|\\___| |_|  |_|\\__,_|_.__/ ");
            Console.WriteLine("                                                                            __/ |                               ");
            Console.WriteLine("                                                                           |___/                                ");

        }
            static void logintitle()
            {
                Console.WriteLine("                                                                                                                 ");
                Console.WriteLine("                                               To access the system, Please LOG IN....");
                Console.WriteLine("                            --------------------------------------------------------------------------                                    ");
                Console.WriteLine("                                                             Login Menu                                                 ");
                Console.WriteLine("                            --------------------------------------------------------------------------              ");
                Console.WriteLine("                                                                                                                       ");

            }
    }
}
