using Advanced_Csharp_Lab1.classes.Organization;
using Advanced_Csharp_Lab1.Classes.Menu;
using System.Collections.Generic;
using Advanced_Csharp_Lab1.Enums;
using Advanced_Csharp_Lab1.Classes.Employee.Programmer;
using Advanced_Csharp_Lab1.Classes;
using System.IO;
using Advanced_Csharp_Lab1.classes;

namespace Advanced_Csharp_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //demonstration 
            Organization org = new Organization();

            org.Name = "Bertils Webbyrå";

            int id1 = org.NewMentor("Bertil", "Bongo", 30000 , Specialization.C_Sharp);
            int id2 = org.NewMentor("Mange", "Schmidt", 30000, Specialization.Java);
            int id3 = org.NewMentor("Keso", "Osten", 30000, Specialization.C_PlusPlus);
            int id4 = org.NewMentor("Kevin", "Zaza", 30000, Specialization.C_Sharp);

            //beginners get assigned to a mentor through load balancing on creation

            int id5 = org.NewBeginner("Kicki", "Jonsson", 25000, Specialization.C_Sharp);
            int id6 = org.NewBeginner("Herman", "Dum", 25000, Specialization.Java);
            int id7 = org.NewBeginner("Anders", "Greppman", 25000, Specialization.C_Sharp);
            int id8 = org.NewBeginner("Joppe", "Luring", 25000, Specialization.C_PlusPlus);
            int id9 = org.NewBeginner("Anton", "Svensson", 25000, Specialization.C_Sharp);


            //upgrade beginner, this removes mentee from mentor
            org.UpgradeBeginner(id9);

            //update their salary
            org.Mentors[id9].SetSalary(30000);

            //change language of mentor, this automatically reassigns their mentees to someone else.
            org.languageUpdate(org.Mentors[id1], Specialization.C_PlusPlus);



            //declare top level menu
            Menu menu = new Menu("Main Menu");

            menu.instructions = "Navigate using arrow keys, ENTER to select, ESC to exit";

            //add options
            menu.addMenuOption(new MenuOption("Print organization report", () =>
            {
                Console.Clear();

                //generate detailed report
                Console.WriteLine(org);

                //go back to main
                Console.ReadKey();
                menu.show();
            }));

            menu.addMenuOption(new MenuOption("Show total salary bill", () =>
            {
                Console.Clear();
                // using delegate with anonymous function, show total salary bill, also using a second inner delegate in static class to switch colors
                org.GetSalaryBillTotal((total) =>
                {
                    ConsoleTheme.highLight(() =>
                    {
                        Console.Write($"Total salary bill: {total}");

                    });

                    Console.Write(Environment.NewLine);
                });

                //go back to main
                Console.ReadKey();
                menu.show();
            }));

            menu.addMenuOption(new MenuOption("Show read from old document file", () =>
            {
                Console.Clear();
                //read from file
                OldDocumentReader.PrintfromDocument("Employees.txt");

                //go back to main
                Console.ReadKey();
                menu.show();
            }));

            menu.addMenuOption(new MenuOption("Show use of Icomparable by sorting employees by last name", () =>
            {
                Console.Clear();
                //using icomparable
                Console.WriteLine(org.ShowEmployeesByLastName());

                //go back to main
                Console.ReadKey();
                menu.show();
            }));



            menu.addMenuOption(new MenuOption("Exit", () =>
            {
                Console.Clear();
                Environment.Exit(0);
            }));

            //show top level menu
            menu.show();

        }
    }
}