using System;
using System.Collections.Generic;
using CybersecurityChatbot;

namespace CybersecurityChatbot
{
    public class Chatbot

    {
        private string UserName;
        private Dictionary<string, string> responses;

        public Chatbot()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase
            )
            {
                { "hello", "Hello! I'm your cybersecurity awareness bot. How can I assist you today?" },
                { "what is phishing?", "Phishing is a type of cyber attack where attackers impersonate legitimate organizations to steal sensitive information." },
                { "how to create a strong password?", "A strong password should be at least 12 characters long, include a mix of letters, numbers, and special characters." },
                { "what is two-factor authentication?", "Two-factor authentication (2FA) adds an extra layer of security by requiring a second form of verification in addition to your password." },
                { "how to recognize a secure website?", "Look for 'https://' in the URL and a padlock icon in the address bar to ensure the website is secure." }
            };
        }
    
        public void GreetUser( )
       {
           Console.ForegroundColor = ConsoleColor.Cyan;
           ConsoleUI.TypeMessage("Welcome to the Cybersecurity Awareness Bot, My Name is CUERER, a chatbot assistant!");
           ConsoleUI.TypeMessage("Please enter your name:");
           Console.ResetColor();

          Console.ForegroundColor = ConsoleColor.Green;
          UserName = Console.ReadLine();
          Console.ResetColor();

          if (!string.IsNullOrWhiteSpace(UserName))
          {
              UserName = UserName.Trim();
              Console.ForegroundColor = ConsoleColor.Green;
              ConsoleUI.TypeMessage($"Nice to meet you, {UserName}! My Name is CUERER, a chatbot assistant. How can I assist you with cybersecurity today?");
          }
          else
          {
              Console.ForegroundColor = ConsoleColor.Yellow;
              ConsoleUI.TypeMessage("No name entered. I'll just call you 'User'. How can I assist you with cybersecurity today?");
              UserName = "User";
          }
          Console.ResetColor();
       }

       public void ProcessUserInput(string input)
       {
        if  (string.IsNullOrWhiteSpace(input))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleUI.TypeMessage("Please enter a valid question or command.");
            Console.ResetColor();
            return;
        }
        if (responses.TryGetValue(input.ToLower(), out string response))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleUI.TypeMessage(response);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleUI.TypeMessage("Sorry, I don't have an answer for that. Please try asking something else or rephrase your question.");
        }
        Console.ResetColor();
         } 
    }
}