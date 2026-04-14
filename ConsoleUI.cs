using System;
using System.Threading

namespace CybersecurityChatbot
{
    public static class ConsoleUI
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ██████╗ ██╗   ██╗███████╗██████╗ ███████╗██████╗ 
 ██╔════╝ ██║   ██║██╔════╝██╔══██╗██╔════╝██╔══██╗
 ██║      ██║   ██║█████╗  ██████╔╝█████╗  ██████╔╝
 ██║      ██║   ██║██╔══╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗ ╚██████╔╝███████╗██║  ██║███████╗██║  ██║
  ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝
            AWARENESS BOT - STAY SAFE ONLINE");
            Console.ResetColor();
        }
        public static void TypeMessage(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay)
            }
            Console.WriteLine();

            
        }
    }
}