using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatbot chatbot = new Chatbot();

            // 1. Display ASCII Art
            ConsoleUI.DisplayAsciiArt();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // 2. Greet User and Get Name
            chatbot.GreetUser();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // 3. Main Chat Loop
            string userInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("You: ");
                userInput = Console.ReadLine();
                Console.ResetColor();

                if (!string.IsNullOrWhiteSpace(userInput) && userInput.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    ConsoleUI.TypeMessage("Goodbye! Stay safe online!");
                    Console.ResetColor();
                    break;
                }

                chatbot.ProcessUserInput(userInput);
                Console.WriteLine("\n" + new string('=', 50) + "\n");

            } while (true);
        }
    }
}

