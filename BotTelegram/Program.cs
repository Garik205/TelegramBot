using BotTelegram.HundlerForBot;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace BotTelegram
{ 
    public class Program : Hundlers
    {
        private static ITelegramBotClient? _botClient; // клиент для работы с Telegram Client Api, который позволяет отправлять сообщения, управлять ботом, подписываться на обновления
        private static ReceiverOptions? _receiverOptions; // Объект с настройками работы бота. Сможем указывть какие типы Update будем получать, Timeout бота и ...


        public static async Task Main()
        {

            _botClient = new TelegramBotClient("6543089403:AAG0KkWyvB8LIbX7BhQB1S9Vpl9MoSpYdz4"); // Присваиваю в поле значение с передаваемым параметром(токен бота)

            _receiverOptions = new ReceiverOptions // присваиваем значение настройки бота
            {
                AllowedUpdates = new[] // Указывкем типы получаемых Update
                {
                    UpdateType.Message, // Сообщения
                },
                ThrowPendingUpdates = false, // Параметр отвечающий за обработку сообщений во время оффлайн бота. True - не обрабатывать, False(default) - обрабатывать               
            };

            using var cts = new CancellationTokenSource();
            
            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
            // UpdateHandler - обработчик приходящих Update
            // ErrorHandler - обработчик ошибок, связанныз с ботом


            var me = await _botClient.GetMeAsync(); // Поле для хранения данных о боте
            Console.WriteLine($"{me.FirstName} бот запущен!");

            await Task.Delay(-1); // Бесконечная задержка

        }
    }
}
