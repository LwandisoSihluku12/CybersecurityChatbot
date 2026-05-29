using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot.WPF
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> _responses;
        private Random _random = new Random();

        public KeywordResponder()
        {
            _responses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "password", new List<string> {
                    "A strong password should be at least 12 characters long and include special characters.",
                    "Never reuse the same password across multiple websites; use a password manager instead.",
                    "Avoid using personal information like birthdays or pet names in your passwords."
                }},
                { "phishing", new List<string> {
                    "Phishing involves attackers sending fake emails to steal your login credentials.",
                    "Always check the sender's email address carefully for slight misspellings.",
                    "Be wary of emails that create a sense of urgency or ask for sensitive information."
                }},
                { "privacy", new List<string> {
                    "Protect your privacy by limiting the amount of personal info you share on social media.",
                    "Regularly review the privacy settings on your online accounts and apps.",
                    "Use a VPN when connecting to public Wi-Fi to keep your browsing data private."
                }},
                { "scam", new List<string> {
                    "If an online offer sounds too good to be true, it's likely a scam.",
                    "Never send money or gift card codes to someone you haven't met in person.",
                    "Scammers often impersonate government agencies or tech support to trick you."
                }},
                { "malware", new List<string> {
                    "Malware is malicious software designed to damage or gain unauthorized access to your computer.",
                    "Keep your operating system and antivirus software updated to protect against malware.",
                    "Avoid clicking on suspicious links or downloading attachments from unknown sources."
                }},
                { "2fa", new List<string> {
                    "Two-factor authentication (2FA) adds a critical second layer of security to your accounts.",
                    "Using an authenticator app is generally more secure than receiving codes via SMS.",
                    "Enable 2FA on all your important accounts, especially email and banking."
                }}
            };
        }

        public string? GetResponse(string input, out string? matchedKeyword)
        {
            matchedKeyword = null;
            foreach (var keyword in _responses.Keys)
            {
                if (input.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    matchedKeyword = keyword;
                    var possibleResponses = _responses[keyword];
                    return possibleResponses[_random.Next(possibleResponses.Count)];
                }
            }
            return null;
        }

        public List<string> GetAllKeywords()
        {
            return _responses.Keys.ToList();
        }
    }
}
