using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.Classes
{
    //class for quickly switching between combinations of text effects
    public delegate void ConsoleColorDelegate();
    public static class ConsoleTheme
    {
        
        private static void standard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void selected()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }

        private static void custom(ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        public static void highLight(ConsoleColorDelegate printMethod)
        {
            selected();
            try
            {       
                printMethod();
            }
            finally
            {
                Console.ResetColor();
                Console.Write(Environment.NewLine);
            }
            
        }

        public static void custom(ConsoleColorDelegate printMethod,ConsoleColor foreground, ConsoleColor background)
        {
            custom(foreground,background);
            try
            {           
            printMethod();
            }
            finally
            {
                Console.ResetColor();
                Console.Write(Environment.NewLine);
            }
            
        }

    }
}
