// Services/TaskAssistant.cs
using System;
using System.Collections.Generic;
using CybersecurityChatbot.WPF.Models;

namespace CybersecurityChatbot.WPF.Services
{
    public class TaskAssistant
    {
        private readonly TaskDatabaseManager _dbManager;

        public TaskAssistant()
        {
            _dbManager = new TaskDatabaseManager();
        }

        public string AddTask(string title, string description, DateTime? reminderDate = null)
        {
            var task = new CybersecurityTask
            {
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                IsCompleted = false
            };
            _dbManager.AddTask(task);
            return $"Task \"{title}\" added successfully. {(reminderDate.HasValue ? $\"I will remind you on {reminderDate.Value:yyyy-MM-dd}.\" : \"No reminder set.\")}";
        }

        public List<CybersecurityTask> GetPendingTasks()
        {
            return _dbManager.GetTasks().FindAll(t => !t.IsCompleted);
        }

        public string CompleteTask(int taskId)
        {
            var task = _dbManager.GetTasks().Find(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                _dbManager.UpdateTask(task);
                return $"Task \"{task.Title}\" marked as completed.";
            }
            return "Task not found.";
        }

        public string DeleteTask(int taskId)
        {
            var task = _dbManager.GetTasks().Find(t => t.Id == taskId);
            if (task != null)
            {
                _dbManager.DeleteTask(taskId);
                return $
```csharp
// ChatBot.cs (Add these lines)
using CybersecurityChatbot.WPF.Services;
using CybersecurityChatbot.WPF.Models; // Add this using statement

// Inside ChatBot class, add a new instance:
private TaskAssistant _taskAssistant = new TaskAssistant();

// Inside ProcessInput method, add logic to handle task commands:
// Example: User says "add task: enable 2FA" or "show tasks"
if (input.StartsWith("add task:", StringComparison.OrdinalIgnoreCase))
{
    string taskTitle = input.Substring("add task:".Length).Trim();
    // Simple reminder parsing for now, can be enhanced with NLP
    DateTime? reminder = null;
    if (taskTitle.Contains("remind me in"))
    {
        // Basic parsing for "remind me in X days"
        var parts = taskTitle.Split(new[] { "remind me in" }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length > 1 && int.TryParse(parts[1].Trim().Split(' ')[0], out int days))
        {
            reminder = DateTime.Now.AddDays(days);
            taskTitle = parts[0].Trim(); // Remove reminder part from title
        }
    }
    return _taskAssistant.AddTask(taskTitle, "", reminder);
}
else if (input.Equals("show tasks", StringComparison.OrdinalIgnoreCase))
{
    var tasks = _taskAssistant.GetPendingTasks();
    if (tasks.Count == 0)
        return "You have no pending cybersecurity tasks.";

    string taskList = "Your pending tasks:\n";
    foreach (var task in tasks)
    {
        taskList += $"- [{(task.IsCompleted ? "X" : " ")}] {task.Title} (Reminder: {task.ReminderDisplay})\n";
    }
    return taskList;
}
else if (input.StartsWith("complete task:", StringComparison.OrdinalIgnoreCase))
{
    if (int.TryParse(input.Substring("complete task:".Length).Trim(), out int taskId))
    {
        return _taskAssistant.CompleteTask(taskId);
    }
    return "Please specify a valid task ID to complete.";
}
else if (input.StartsWith("delete task:", StringComparison.OrdinalIgnoreCase))
{
    if (int.TryParse(input.Substring("delete task:".Length).Trim(), out int taskId))
    {
        return _taskAssistant.DeleteTask(taskId);
    }
    return "Please specify a valid task ID to delete.";
}
// ... existing ProcessInput logic ...