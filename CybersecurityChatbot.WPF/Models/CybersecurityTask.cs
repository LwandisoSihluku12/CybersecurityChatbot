// Models/CybersecurityTask.cs
using System;

namespace CybersecurityChatbot.WPF.Models
{
    public class CybersecurityTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public string ReminderDisplay => ReminderDate.HasValue 
            ? ReminderDate.Value.ToString("yyyy-MM-dd HH:mm") 
            : "No Reminder";
    }
}