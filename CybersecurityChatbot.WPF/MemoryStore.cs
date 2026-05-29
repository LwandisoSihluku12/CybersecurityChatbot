using System;

namespace CybersecurityChatbot.WPF
{
    public class MemoryStore
    {
        public string UserName { get; set; } = "User";
        public string FavoriteTopic { get; set; } = string.Empty;

        public string GetPersonalisedOpener()
        {
            if (!string.IsNullOrEmpty(FavoriteTopic))
                return $"As someone interested in {FavoriteTopic}, you might find this information particularly useful.";
            return string.Empty;
        }
        
    }

    
}