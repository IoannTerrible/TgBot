using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;

using static Deliverance.Handlers;

namespace Deliverance
{
    class Program
    {
        public static long chatId;
        public static EncouragementSender EsSender;

        private static ITelegramBotClient _botClient;
        private static ReceiverOptions _receiverOptions;

        static async Task Main()
        {
            Dictionary <string,string> config = ConfigLoader.LoadConfig("config");
            chatId = long.Parse(config["chatId"]);
            string token = config["token"];

            _botClient = new TelegramBotClient(token);
            _receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[] { UpdateType.Message },
                ThrowPendingUpdates = true,
            };

            using CancellationTokenSource cts = new();
            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);

            var me = await _botClient.GetMeAsync();
            Console.WriteLine($"{me.FirstName} Live!");

            string[] messages = LoadMessagesFromFile("messages.txt");

            EsSender = new EncouragementSender(_botClient, chatId, messages);
            EsSender.Start();

            await Task.Delay(-1);
        }

        static string[] LoadMessagesFromFile(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when load messages: {ex.Message}");
                return Array.Empty<string>();
            }
        }
    }
}