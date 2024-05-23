using System;
using System.Timers;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Deliverance
{
    public class EncouragementSender
    {
        public long chatId;

        private readonly ITelegramBotClient _botClient;
        private readonly string[] _messages;
        private readonly System.Timers.Timer _timer;
        private readonly Random _random;
        private double _remainingTime;

        public EncouragementSender(ITelegramBotClient botClient, long chatId, string[] messages)
        {
            _botClient = botClient;
            this.chatId = chatId;
            _messages = messages;
            _random = new Random();

            _timer = new System.Timers.Timer(1000); 
            _timer.Elapsed += OnTimedEvent;
        }

        private void SetRandomInterval()
        {
            _remainingTime = _random.Next(20 * 60 * 1000, 30 * 60 * 1000);
            _timer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _remainingTime -= 1000;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Remaining time: {TimeSpan.FromMilliseconds(_remainingTime):hh\\:mm\\:ss}");
            Console.ResetColor();

            if (_remainingTime <= 0)
            {
                _timer.Stop();

                SendEncouragementMessage();

                SetRandomInterval();
            }
        }

        public async void SendEncouragementMessage()
        {
            string message = _messages[_random.Next(_messages.Length)];

            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                parseMode: ParseMode.Markdown
            );
        }

        public void Start()
        {
            SendEncouragementMessage();
            SetRandomInterval();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
