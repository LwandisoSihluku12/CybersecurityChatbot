using System;
using System.Media;

namespace CybersecurityChatbot.WPF
{
    public class ChatBot
    {
        private KeywordResponder _keywords = new KeywordResponder();
        private SentimentDetector _sentiment = new SentimentDetector();
        private MemoryStore _memory = new MemoryStore();
        private bool _awaitingName = true;
        private string? _lastTopic;

        public string GetGreeting() => "Welcome to CUERER!\nPlease enter your name to begin:";

        public string ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "Please enter something.";

            if (_awaitingName)
            {
                _memory.UserName = input.Trim();
                _awaitingName = false;
                return $"Nice to meet you, {_memory.UserName}! How can I help you today?";
            }

            if (input.Contains("tell me more", StringComparison.OrdinalIgnoreCase) && _lastTopic != null)
                return $"Regarding {_lastTopic}: {_keywords.GetResponse(_lastTopic, out _)}";

            Sentiment mood = _sentiment.Detect(input);
            string sResponse = _sentiment.GetSentimentResponse(mood);
            string? kResponse = _keywords.GetResponse(input, out string? matched);

            if (matched != null)
            {
                _lastTopic = matched;
                return $"{sResponse}{_memory.GetPersonalisedOpener()}{kResponse!}";
            }

            return "I'm not sure I understand. Try asking about 'phishing' or 'passwords'.";
        }

        public void PlayGreeting(string path)
        {
            try { new SoundPlayer(path).Play(); } catch { }
        }
    }
}
