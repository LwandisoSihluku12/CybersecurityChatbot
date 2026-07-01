// Windows/QuizWindow.xaml.cs
using System.Windows;
using System.Windows.Controls;
using CybersecurityChatbot.WPF.Services;
using CybersecurityChatbot.WPF.Models;
using System.Linq;
using System.Windows.Media;

namespace CybersecurityChatbot.WPF.Windows
{
    public partial class QuizWindow : Window
    {
        private QuizGame _quizGame;
        private QuizQuestion _currentQuestion;
        private int _selectedOptionIndex = -1;

        public QuizWindow( )
        {
            InitializeComponent();
            _quizGame = new QuizGame();
            DisplayNextQuestion();
        }

        private void DisplayNextQuestion()
        {
            _currentQuestion = _quizGame.GetNextQuestion();
            if (_currentQuestion != null)
            {
                QuestionTextBlock.Text = _currentQuestion.Question;
                OptionsPanel.Children.Clear();
                _selectedOptionIndex = -1;
                SubmitButton.IsEnabled = true;
                NextButton.IsEnabled = false;
                RestartButton.Visibility = Visibility.Collapsed;

                for (int i = 0; i < _currentQuestion.Options.Count; i++)
                {
                    RadioButton rb = new RadioButton
                    {
                        Content = _currentQuestion.Options[i],
                        Foreground = Brushes.White,
                        FontSize = 14,
                        Margin = new Thickness(0, 5, 0, 5),
                        Tag = i // Store the index of the option
                    };
                    rb.Checked += Option_Checked;
                    OptionsPanel.Children.Add(rb);
                }
            }
            else
            {
                // Quiz finished
                QuestionTextBlock.Text = _quizGame.GetQuizResult();
                OptionsPanel.Children.Clear();
                SubmitButton.Visibility = Visibility.Collapsed;
                NextButton.Visibility = Visibility.Collapsed;
                RestartButton.Visibility = Visibility.Visible;
            }
        }

        private void Option_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.IsChecked == true)
            {
                _selectedOptionIndex = (int)rb.Tag;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOptionIndex != -1)
            {
                string feedback = _quizGame.SubmitAnswer(_selectedOptionIndex);
                MessageBox.Show(feedback, "Quiz Feedback");
                SubmitButton.IsEnabled = false;
                NextButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Please select an answer.", "Error");
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayNextQuestion();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            _quizGame.ResetQuiz();
            DisplayNextQuestion();
            SubmitButton.Visibility = Visibility.Visible;
            NextButton.Visibility = Visibility.Visible;
        }
    }
}