using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CybersecurityChatbot.WPF
{
    public partial class MainWindow : Window
    {
        private ChatBot _chatBot;

        public MainWindow()
        {
            InitializeComponent();
            _chatBot = new ChatBot();
            
            AsciiDisplay.Text = @"
  ██████╗ ██╗   ██╗███████╗██████╗ ███████╗██████╗ 
 ██╔════╝ ██║   ██║██╔════╝██╔══██╗██╔════╝██╔══██╗
 ██║      ██║   ██║█████╗  ██████╔╝█████╗  ██████╔╝
 ██║      ██║   ██║██╔══╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗ ╚██████╔╝███████╗██║  ██║███████╗██║  ██║
  ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝";

            // Initial greeting
            AppendMessage("CUERER", _chatBot.GetGreeting(), Brushes.Cyan);
        }

        // 1. Audio plays IMMEDIATELY when window is visible
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _chatBot.PlayGreeting("welcome.wav");
            UserInput.Focus();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e) => HandleInput();
        private void UserInput_KeyDown(object sender, KeyEventArgs e) { if (e.Key == Key.Enter) HandleInput(); }

        private void HandleInput()
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            // 2. Different Colors (User = Green)
            AppendMessage("You", input, Brushes.LightGreen);
            UserInput.Clear();

            string response = _chatBot.ProcessInput(input);
            // Check for specific response to launch quiz window
           if (response.Contains("I'll open a new window for it."))
           {
              AppendMessage("CUERER", response, Brushes.Cyan);
              // Launch the quiz window
              CybersecurityChatbot.WPF.Windows.QuizWindow quizWindow = new CybersecurityChatbot.WPF.Windows.QuizWindow();
             quizWindow.Show();
           }
        else
           {
                // 2. Different Colors (Bot = Cyan)
                AppendMessage("CUERER", response, Brushes.Cyan);
            }   

            // 2. Different Colors (Bot = Cyan)
            AppendMessage("CUERER", response, Brushes.Cyan);
            
            ChatScroller.ScrollToEnd();
        }

        // This helper method creates the colored text
        private void AppendMessage(string sender, string message, Brush color)
        {
            Paragraph p = new Paragraph();

            // Add Sender Name
            p.Inlines.Add(new Run($"{sender}: ") { Foreground = color, FontWeight = FontWeights.Bold });

            // Add Message
            p.Inlines.Add(new Run(message) { Foreground = Brushes.White });

            // Use object so we can pattern-match at runtime whether the control
            // is a RichTextBox or a TextBlock (XAML may declare either).
            object chatObj = ChatDisplay;

            if (chatObj is System.Windows.Controls.RichTextBox rtb)
            {
                rtb.Document.Blocks.Add(p);

                // Add Separator
                Paragraph sep = new Paragraph(new Run("-----------------------------------"))
                {
                    Foreground = Brushes.DimGray,
                    FontSize = 8
                };

                rtb.Document.Blocks.Add(sep);
            }
            else if (chatObj is System.Windows.Controls.TextBlock tb)
            {
                tb.Inlines.Add(new Run($"{sender}: ") { Foreground = color, FontWeight = FontWeights.Bold });
                tb.Inlines.Add(new Run(message) { Foreground = Brushes.White });
                tb.Inlines.Add(new LineBreak());
                tb.Inlines.Add(new Run("-----------------------------------") { Foreground = Brushes.DimGray, FontSize = 8 });
            }
        }

    }
}

