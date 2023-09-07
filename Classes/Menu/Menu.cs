using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.Classes.Menu
{
    public class Menu
    {
        //declare variables
        private string Title;
        private List<MenuOption> Items;
        private int CurrentSelectionIndex = 0;
        public string instructions;

        //constructor
        public Menu(string Title)
        {
            this.Items = new List<MenuOption>();
            this.Title = Title;
        }
        public Menu(string Title, List<MenuOption> Items)
        {
            this.Items = Items;
            this.Title = Title;
        }

        public MenuOption MenuOption
        {
            get => default;
            set
            {
            }
        }

        public void addMenuOption(MenuOption option)
        {
            Items.Add(option);
        }
       
        //methods
        public void show()
        {
            //first clear console
            Console.Clear();

            //then print menu title
            string menuTitle = this.Title + "\n\n";
            Console.WriteLine(menuTitle);

            //loop
            for (int i = 0; i < Items.Count; i++)
            {
                //QoL
                var item = Items[i];

                //generate string
                string result = (i + 1) + ". " + item.Name;

                //change selection color
                if (i == CurrentSelectionIndex) {
                    ConsoleTheme.highLight(() =>
                    {
                        Console.Write(result);

                    });
                }
                else
                {
                    Console.WriteLine(result);
                }

            }

            //then print instructions
            Console.WriteLine(Environment.NewLine+instructions);

            //then wait for navigation
            navigate();
        }

        

        public void navigate()
        {
            bool success = false;

            //set loop
            while (!success) { 

                //wait for key
                var keypress = Console.ReadKey();

                //check what key
                switch(keypress.Key)
                {
                    //if up
                    case ConsoleKey.UpArrow :
                        up();
                        success = true;
                        break;

                    case ConsoleKey.DownArrow :
                        down();
                        success = true;
                        break;

                    case ConsoleKey.Escape :
                        close();
                        success = true;
                        break;
                    case ConsoleKey.Enter:
                        select();
                        success = true;
                        break;
                }
            }
        }

        public void up()
        {
            if (CurrentSelectionIndex != 0) {
                CurrentSelectionIndex--;
            }         
            show();     
        }

        public void down()
        {
            if (CurrentSelectionIndex < Items.Count-1)
            {
                CurrentSelectionIndex++;
            }
            show();
        }

        //runs the delegate in selected item
        public void select() {
            Items[CurrentSelectionIndex].Run();
        }
        //closes the 
        public void close() { 
            Environment.Exit(0);
        }

    }
}
