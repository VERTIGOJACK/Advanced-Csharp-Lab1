using Advanced_Csharp_Lab1.Classes.Menu;
using System.Collections.Generic;

namespace Advanced_Csharp_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //declare top level menu
            Menu menu = new Menu("Main Menu");

            //add options
            menu.addMenuOption(new MenuOption("Organization", () =>
            {
                //declare new top level menu
                Menu orgMenu = new Menu("Organization menu");

                //add options
                orgMenu.addMenuOption(new MenuOption("Departments", () =>
                {
                    Console.Clear();
                    Console.WriteLine("departmenteeeeeeeeee");
                }));

                //do the things
                Console.Clear();
                orgMenu.show();
            }));

            menu.addMenuOption(new MenuOption("Departments", () =>
            {
                Console.Clear();
                Console.WriteLine("deopertment deapartmeny");
            }));

            menu.addMenuOption(new MenuOption("Employees", () =>
            {
                Console.Clear();
                Console.WriteLine("eployos the boyos");
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