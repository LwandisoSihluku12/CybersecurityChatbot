*Cybersecurity Awareness Chatbot (CUERER)*
Overview
The Cybersecurity Awareness Chatbot, affectionately named CUERER, is a console-based application built in C# (.NET 8.0). Designed to educate users on essential cybersecurity concepts, CUERER provides interactive responses to common questions regarding online safety. The application features a user-friendly command-line interface complete with ASCII art, colored text output, a simulated typing effect, and audio greetings to enhance the user experience.
*Features:*
Interactive Q&A: Answers fundamental cybersecurity questions (e.g., "What is phishing?", "How to create a strong password?", "What is two-factor authentication?").
Audio Greeting: Plays a welcome audio file (welcome.wav) upon startup to greet the user.
Dynamic UI Elements: Utilizes colored console text and a simulated typing effect to make the interaction feel more natural and engaging.
ASCII Art: Displays a custom ASCII art banner for visual appeal when the application launches.
Personalized Experience: Asks for the user's name and personalizes responses throughout the session.
Prerequisites
To build and run this project, you will need the following installed on your system:
.NET 8.0 SDK
A compatible IDE such as Visual Studio 2022 or Visual Studio Code with the C# extension.
Platform Considerations
The audio playback feature utilizes the System.Media.SoundPlayer class from the System.Windows.Extensions package. This functionality is specific to the Windows operating system. If you run the application on macOS or Linux, the audio playback may fail gracefully, logging a note without crashing the application.
Installation and Setup
Clone or Download the Repository:
Extract the project files to your desired directory.
Navigate to the Project Directory:
Open your terminal or command prompt and navigate to the folder containing the .sln or .csproj file.
cd path/to/CybersecurityChatbot
Restore Dependencies:
Run the following command to restore the required NuGet packages (specifically System.Windows.Extensions):
dotnet restore
Build the Project:
Compile the application to ensure there are no errors.
dotnet build
Usage
To start the chatbot, run the following command in your terminal from the project directory:
dotnet run
Interacting with CUERER
Startup: Upon launching, you will hear a welcome audio prompt (if on Windows) and see the CUERER ASCII art banner.
Name Entry: The bot will ask for your name. Type it in and press Enter.
Ask Questions: You can ask questions such as:
"Hello"
"What is phishing?"
"How to create a strong password?"
"What is two-factor authentication?"
"How to recognize a secure website?"
Exit: To close the application, simply type exit and press Enter.
Project Structure
Program.cs: The main entry point of the application. It initializes the chatbot, handles the main loop, and manages user input/output.
Chatbot.cs: Contains the core logic for the chatbot, including the dictionary of predefined responses, the audio playback method, and the greeting logic.
ConsoleUI.cs: Manages the visual aspects of the console, including displaying the ASCII art and implementing the typing effect for messages.
CybersecurityChatbot.csproj: The project configuration file specifying the target framework (.NET 8.0) and dependencies.
welcome.wav: The audio file played when the application starts.
Customization
You can easily expand the chatbot's knowledge base by adding new question-answer pairs to the responses dictionary located in the Chatbot() constructor within Chatbot.cs.
