// Windows/TaskWindow.xaml.cs
using System.Windows;
using CybersecurityChatbot.WPF.Services;
using CybersecurityChatbot.WPF.Models;
using System.Linq;

namespace CybersecurityChatbot.WPF.Windows
{
    public partial class TaskWindow : Window
    {
        private TaskAssistant _taskAssistant;

        public TaskWindow( )
        {
            InitializeComponent();
            _taskAssistant = new TaskAssistant();
            LoadTasks();
        }

        private void LoadTasks()
        {
            TaskListView.ItemsSource = _taskAssistant.GetPendingTasks();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadTasks();
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            // For simplicity, we'll use a MessageBox. You could create a dedicated AddTaskWindow.
            string title = Microsoft.VisualBasic.Interaction.InputBox("Enter task title:", "Add New Task", "");
            if (!string.IsNullOrWhiteSpace(title))
            {
                string description = Microsoft.VisualBasic.Interaction.InputBox("Enter task description (optional):");
                string reminderInput = Microsoft.VisualBasic.Interaction.InputBox("Enter reminder date (YYYY-MM-DD) or leave blank:");
                DateTime? reminderDate = null;
                if (DateTime.TryParse(reminderInput, out DateTime date))
                {
                    reminderDate = date;
                }
                MessageBox.Show(_taskAssistant.AddTask(title, description, reminderDate));
                LoadTasks();
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is CybersecurityTask selectedTask)
            {
                MessageBox.Show(_taskAssistant.CompleteTask(selectedTask.Id));
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Please select a task to complete.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is CybersecurityTask selectedTask)
            {
                MessageBox.Show(_taskAssistant.DeleteTask(selectedTask.Id));
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }
    }
}