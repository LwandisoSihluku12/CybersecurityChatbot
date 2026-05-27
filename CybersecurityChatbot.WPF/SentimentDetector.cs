using System;
using System.Collections.Generic;

namespace CybersecurityChatbotWPF
{
    public enum Sentiment { Neutral, Worried, Curious, Frustrated, Happy }

    public class SentimentDetector
    {
        private Dictionary<Sentiment, List<string>>_triggers;

        public SentimentDetector()
        {
            _triggers = new Dictionary<Sentiment, List<string>>()
            {
                { Sentiment.Worried, new List<string> { "worried", "scared", "afraid", "anxious", "unsafe" } },
                { Sentiment.Curious, new List<string> { "curious", "wondering", "interested", "how does" } },
                { Sentiment.Frustrated, new List<string> { "frustrated", "annoyed", "confused", "don't understand" } },
                { Sentiment.Happy, new List<string> { "great", "thanks", "helpful", "awesome" } }    
            };
        }

        public Sentiment Detect(string input)
        {
            foreach (var entry in _triggers)
            {
                foreach (var word in entry.Value)
                {
                    if (input.Contains(word, StringComparison.OrdinalIgnoreCase))
                        return entry.Key;
                }
            }
            return Sentiment.Neutral;
        }

        public string GetSentimentResponse(Sentiment sentiment)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return "I understand your concerns. Let's work together to find a solution.";
                case Sentiment.Curious:
                    return "That's a great question! Let me explain.";
                case Sentiment.Frustrated:
                    return "I see you're having trouble. Let's try to figure this out together.";
                case Sentiment.Happy:
                    return "I'm glad I could help! If you have any more questions, feel free to ask.";
                default:
                    return null;
            }
        }


     
    }
}