using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This must match the name of your logic class
        private ChatBot _chatBot;

        

        public MainWindow()
        {
            InitializeComponent();
            _chatBot = new ChatBot();

            // 1. Set the ASCII Art (Make sure x:Name="AsciiDisplay" exists in XAML)
            AsciiDisplay.Text = @"
  ██████╗ ██╗   ██╗███████╗██████╗ ███████╗██████╗ 
 ██╔════╝ ██║   ██║██╔════╝██╔══██╗██╔════╝██╔══██╗
 ██║      ██║   ██║█████╗  ██████╔╝█████╗  ██████╔╝
 ██║      ██║   ██║██╔══╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗ ╚██████╔╝███████╗██║  ██║███████╗██║  ██║
  ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝";

            // 2. Play the audio file
            _chatBot.PlayGreeting("welcome.wav");

            // 3. Show initial greeting
            ChatDisplay.Text = "CUERER: " + _chatBot.GetGreeting() + "\n" + new string('-', 40);
        }

        // This runs when the SEND button is clicked
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // This runs when you press ENTER in the text box
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string input = UserInput.Text;

            // Don't do anything if the input is empty
            if (string.IsNullOrWhiteSpace(input)) return;

            // 1. Show what the user said
            ChatDisplay.Text += $"\nYou: {input}\n";

            // 2. Get the bot's response and show it
            string response = _chatBot.ProcessInput(input);
            ChatDisplay.Text += $"\nCUERER: {response}\n";
            ChatDisplay.Text += new string('-', 40) + "\n";

            // 3. Clear the input box for the next message
            UserInput.Clear();

            // 4. Automatically scroll to the bottom so the new message is visible
            ChatScroller.ScrollToEnd();
        }
    }

}
