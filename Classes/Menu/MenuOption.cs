using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.Classes.Menu
{
    public class MenuOption
    {
        public string Name { get; set; }
        public Action Run { get; set; }

        //    MenuOption option = new MenuOption("Do Something", () =>
        //{
        //    Console.WriteLine("Doing something...");
        //});

        public MenuOption(string name, Action method)
        {
            Name = name;
            Run = method;
        }
    }
}
