# CUERER - Cybersecurity Awareness Bot (Part 2)

## 🛡️ Project Description
CUERER is an advanced, educational chatbot designed to raise awareness about cybersecurity threats. Upgraded from a console application to a modern **Windows Presentation Foundation (WPF)** interface, CUERER now features intelligent keyword recognition, emotional sentiment detection, and user memory to provide a personalized learning experience.

**Student Name:** [Your Name]  
**Student Number:** [Your Student Number]

---

## 🚀 New Features in Part 2
- **Enhanced WPF GUI**: A professional dark-themed interface with a glowing header, shield iconography, and a responsive layout.
- **Colored Chat Interface**: Distinct color coding for messages (Cyan for CUERER, Light Green for the User) to improve readability.
- **Sentiment Detection**: The bot recognizes user emotions (Worried, Curious, Frustrated, Happy) and responds with empathy before providing technical advice.
- **Intelligent Keyword Recognition**: Detects topics like Phishing, Passwords, Privacy, Scams, Malware, and 2FA.
- **Randomized Advice**: Each topic has multiple unique responses to keep the conversation engaging and informative.
- **Memory & Recall**: Remembers the user's name and interests to personalize future interactions.
- **Immediate Audio Greeting**: Automatically plays a voice greeting (`welcome.wav`) the moment the application launches.
- **Conversation Flow**: Handles follow-up questions like "tell me more" or "explain more" using context memory.

---

## 🛠️ Technical Architecture (OOP)
The project follows clean **Object-Oriented Programming** principles by separating logic into modular classes:
- **`MainWindow.xaml.cs`**: Thin UI layer handling events and colored message rendering.
- **`ChatBot.cs`**: The central coordinator that routes inputs through the specialized logic engines.
- **`KeywordResponder.cs`**: Manages the dictionary of cybersecurity topics and randomized response selection.
- **`SentimentDetector.cs`**: Analyzes the emotional tone of user messages.
- **`MemoryStore.cs`**: Stores and recalls user-specific data like names and favorite topics.

---

## 📦 Prerequisites & Setup
- **OS**: Windows 10/11
- **Framework**: .NET 8.0 SDK
- **IDE**: Visual Studio 2022

### **Installation Instructions**
1. Clone the repository to your local machine.
2. Open `CybersecurityChatbot.sln` in Visual Studio.
3. **Audio Setup**: Ensure `welcome.wav` is in the project folder. Right-click the file in Visual Studio -> Properties -> set **Copy to Output Directory** to "Copy always".
4. Press **F5** to build and run.

---

## 🎥 Submission Links & Proof
- **YouTube Demo**: [Insert Your Unlisted YouTube Link Here]
- **GUI Screenshot**: [Insert Link/Path to your Screenshot]
- **GitHub Actions Proof**: [Insert Screenshot of the Green Tick from your CI Workflow]

---

## 📈 Version Control
- **Commits**: Minimum of 6 meaningful commits documenting the development process.
- **Releases**: 
    - `v2.0`: Core logic and modular class implementation.
    - `v2.1`: Final GUI styling, colored chat, and audio integration.
