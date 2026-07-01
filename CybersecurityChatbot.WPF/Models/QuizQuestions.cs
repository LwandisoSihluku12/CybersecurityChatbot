// Models/QuizQuestion.cs
using System.Collections.Generic;

namespace CybersecurityChatbot.WPF.Models
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }

        public bool IsTrueFalse => Options == null || Options.Count == 2 && (Options[0].ToLower() == "true" || Options[0].ToLower() == "false");
    }
}