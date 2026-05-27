using System;

namespace CybersecurityChatbotWPF
{
    public class MemoryStore
    {
        public string UserName { get; set; } = "User";
        public string FavoriteTopic { get; set; }

        public string GetPersonalisedOpener()
        {
            if (!string.IsNullOrEmpty(FavoriteTopic))
            
               return $"As someone interested in {FavoriteTopic}, you might find this information particularly useful.";
            return null;
        }
        
    }

    
}