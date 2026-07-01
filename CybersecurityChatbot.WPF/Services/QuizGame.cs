// Services/QuizGame.cs
using System;
using System.Collections.Generic;
using CybersecurityChatbot.WPF.Models;
using System.Linq;

namespace CybersecurityChatbot.WPF.Services
{
    public class QuizGame
    {
        private List<QuizQuestion> _questions;
        private int _currentQuestionIndex;
        private int _score;
        private Random _random = new Random();

        public QuizGame()
        {
            _questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new List<string> { "A type of fishing", "An attempt to trick you into revealing personal info", "A computer virus", "A strong password" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Phishing is a social engineering technique used to steal user data, including login credentials and credit card numbers."
                },
                new QuizQuestion
                {
                    Question = "True or False: It's safe to reuse the same password for all your online accounts.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Reusing passwords is very risky. If one account is compromised, all others using the same password become vulnerable."
                },
                new QuizQuestion
                {
                    Question = "What does 2FA stand for?",
                    Options = new List<string> { "Two-Factor Authorization", "Two-Factor Authentication", "Two-File Access", "Two-Step Approval" },
                    CorrectAnswerIndex = 1,
                    Explanation = "2FA adds an extra layer of security by requiring two different methods of verification."
                },
                new QuizQuestion
                {
                    Question = "Which of these is a strong password component?",
                    Options = new List<string> { "Your birthday", "Your pet's name", "A mix of uppercase, lowercase, numbers, and symbols", "The word 'password'" },
                    CorrectAnswerIndex = 2,
                    Explanation = "Strong passwords are long and complex, making them difficult to guess or crack."
                },
                new QuizQuestion
                {
                    Question = "True or False: Public Wi-Fi networks are always secure for sensitive transactions.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Public Wi-Fi networks are often unsecured and can be easily intercepted by attackers. Always use a VPN."
                },
                new QuizQuestion
                {
                    Question = "What is malware?",
                    Options = new List<string> { "Good software", "Malicious software", "A type of hardware", "A programming language" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Malware is any software intentionally designed to cause damage to a computer, server, client, or computer network."
                },
                new QuizQuestion
                {
                    Question = "Which of these is a common sign of a phishing email?",
                    Options = new List<string> { "Perfect grammar", "A generic greeting (e.g., 'Dear Customer')", "Official company logo", "No links" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Phishing emails often use generic greetings, urgent language, and suspicious links."
                },
                new QuizQuestion
                {
                    Question = "True or False: It's okay to click on links from unknown senders if the email looks important.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Never click on suspicious links, especially from unknown senders. It could lead to malware or phishing sites."
                },
                new QuizQuestion
                {
                    Question = "What is the best way to protect your online privacy?",
                    Options = new List<string> { "Share everything on social media", "Use a VPN and review privacy settings", "Never use the internet", "Give out personal info freely" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Using a VPN, reviewing privacy settings, and being mindful of what you share online are key to protecting your privacy."
                },
                new QuizQuestion
                {
                    Question = "True or False: Antivirus software can protect you from all types of cyber threats.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Antivirus software is essential, but it's not a complete solution. A combination of security practices is needed."
                }
            };
            ShuffleQuestions();
        }

        private void ShuffleQuestions()
        {
            _questions = _questions.OrderBy(a => _random.Next()).ToList();
        }

        public QuizQuestion GetNextQuestion()
        {
            if (_currentQuestionIndex < _questions.Count)
            {
                return _questions[_currentQuestionIndex];
            }
            return null;
        }

        public string SubmitAnswer(int selectedOptionIndex)
        {
            if (_currentQuestionIndex >= _questions.Count) return "Quiz finished.";

            QuizQuestion currentQuestion = _questions[_currentQuestionIndex];
            string feedback;

            if (selectedOptionIndex == currentQuestion.CorrectAnswerIndex)
            {
                _score++;
                feedback = "Correct! ";
            }
            else
            {
                feedback = "Incorrect. ";
            }
            feedback += currentQuestion.Explanation;

            _currentQuestionIndex++;
            return feedback;
        }

        public string GetQuizResult()
        {
            return $"Quiz finished! You scored {_score} out of {_questions.Count}.\n" +
                   (_score >= _questions.Count / 2 ? "Great job! You're a cybersecurity pro!" : "Keep learning to stay safe online!");
        }

        public void ResetQuiz()
        {
            _currentQuestionIndex = 0;
            _score = 0;
            ShuffleQuestions();
        }
    }
}