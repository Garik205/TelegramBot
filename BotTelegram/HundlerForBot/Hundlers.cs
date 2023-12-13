using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotTelegram.HundlerForBot
{
    public class Hundlers
    {

         protected static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
         {
			try // обработчик ошибок, чтобы в случае ошибок мой бот не падал
			{
				switch (update.Type) // для обработки Update
				{
					case UpdateType.Message:
					{
							botClient?.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Привет! У меня будет своя реферальная система, а также я смогу показывать погоду. Разработчик сейчас этим занимается!)");
                            Console.WriteLine("Пришло новое сообщение!");
							Console.WriteLine($"ID User: {(update.Message)?.Chat.Id}. Сообщение: {(update.Message)?.Text}");
                            return;
					}
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}
         }

		protected static Task ErrorHandler(ITelegramBotClient telegramBotClient, Exception error, CancellationToken cancellationToken)
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
