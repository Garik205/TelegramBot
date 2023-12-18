using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using System.Net;

namespace BotTelegram.HundlerForBot
{
    public class Hundlers
    {
        private long _botId { get; set; }

        public Hundlers(long botId)
        {
            _botId = botId;
        }
        public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            //throw new Exception();

            try // обработчик ошибок, чтобы в случае ошибок мой бот не падал
            {
                var t = update.Message;
                //var isBot = update.Message.UserShared.UserId == _botId;

                //if (isBot)
                //    return;


                switch (update.Type) // для обработки Update
                {
                    case UpdateType.Message:
                        {
                            Console.WriteLine($"Пришло новое сообщение!\nID User: {(update.Message)?.Chat.Id}. Сообщение: {(update.Message)?.Text}");

                            var message = update.Message; // Это пременная хранит себе всё, что связано с сообщениями
                            var chat = message.Chat; // Содержит всю информацию о чате

                            switch (message.Type)
                            {
                                case MessageType.Text:
                                    {
                                        if (message.Text == "/start")
                                        {
                                            botClient?.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Привет! Я умею показвыать погоду, выводить Ваш личный реферальный ключ, а также выводить список пользователей, которые зарегестрировались под Вашим реферальным ключом.\nЧтобы использовать весь этот фунцкионал, вы должны авторизоваться!)");
                                            var button = new KeyboardButton("/autorization"); // Создание кнопки
                                            var replyMarkup = new ReplyKeyboardMarkup(button); // Разметка для кнопки

                                            if (message.Text == "/autorization")
                                            {
                                                //bool valid = false; // flag
                                                //long IdChat = message.Chat.Id;
                                                //var autorization = new AutorizationUser();
                                            }
                                            else botClient?.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Вы должны авторизоваться!" );

                                            //var list = new List<KeyboardButton> { new KeyboardButton("\U0001F324Погода"), new KeyboardButton("Реферальный\nключ"), new KeyboardButton("Список пользователей\nиспользующие мой ключ") };

                                                //var markup = new ReplyKeyboardMarkup(list) {ResizeKeyboard = true };

                                                //await botClient.SendTextMessageAsync(chat.Id, "Выберите действие:", replyMarkup: markup); // Сообщение с кнопкой погода

                                            return;
                                        }

                                        else if (message.Text == "Погода")
                                        {
                                            var city = await botClient.SendTextMessageAsync(chat.Id, "Введите город"); // получаем город введённый от пользователя

                                            if (city != null)
                                            {
                                                // отправка запроса погоды к API
                                                var apiKey = "289a1ea5-a89c-4de0-a79f-6095ebcf618a";
                                                var url = $"https://api.weather.yandex.ru/v2/forecast?city={city}";

                                                using (var webClient = new WebClient())
                                                {
                                                    HttpClient client = new HttpClient();
                                                    client.DefaultRequestHeaders.Add("X-Yandex-API-Key", apiKey);

                                                    var json = await client.GetStringAsync(url);

                                                    // Десериалезуем полученные данные
                                                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

                                                    // Формирование сообщения с информацей про погоду
                                                    var weatherMessage = $"Погода в городе {city}:{Environment.NewLine}" +
                                                                        $"Температура: {weatherData?.Main?.Temp}°C{Environment.NewLine}" +
                                                                        $"Описание: {weatherData?.Weather?[0].Description}";
                                                    await botClient.SendTextMessageAsync(chat.Id, weatherMessage);
                                                }
                                            }
                                        }
                                        return;
                                    }
                            }
                            return;
                        }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        public class WeatherData
        {
            public Wether[]? Weather { get; set; }
            public Main? Main { get; set; }
        }

        public class Wether { public string Description { get; set; } = null!; }

        public class Main { public float Temp { get; set; } }


        public Task ErrorHandler(ITelegramBotClient telegramBotClient, Exception error, CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch // поле для хранение кода ошибки и сообщения
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            Console.Write(ErrorMessage);
            return Task.CompletedTask;
        }

    }
}
