# Deliverance
# 📬 EncouragementSender Bot
A simple Telegram bot that sends encouraging messages to users at random intervals. Perfect for keeping up the spirits and motivation throughout the day!

## 📋 Features

- Sends random encouraging messages at intervals between 20 and 30 minutes.
- Logs the remaining time until the next message in the console.
- Configurable via a simple `config` file.

## 🚀 Getting Started

Follow these instructions to get your bot up and running.

### Prerequisites

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0) or later
- A Telegram bot token from [BotFather](https://core.telegram.org/bots#botfather)

### Installation

1. **Clone the repository**
2. **Create a `config` file:**

    In the root of the project directory, create a file named `config` with the following content:
    ```
    chatId=YOUR_CHAT_ID
    token=YOUR_BOT_TOKEN
    ```
3. **Add messages:**
    Create a file named `messages.txt` in the root of the project directory and add your encouraging messages, one per line.
    Example `messages.txt`:
    ```
    You are amazing! 🌟
    Keep up the great work! 💪
    Believe in yourself! 🚀
    ```
4. **Build and run the bot**  
## 📜 Configuration

- **config:** Contains the bot token and chat ID.
- **messages.txt:** Contains the list of messages to be sent.

## 🛠️ Usage

Once the bot is running, it will automatically send messages at intervals between 20 and 30 minutes. The remaining time until the next message will be displayed in the console.

To stop the bot, simply terminate the running process (e.g., press `Ctrl+C` in the terminal).

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your improvements.  

## 📄 License
This project is licensed under the MIT License.
