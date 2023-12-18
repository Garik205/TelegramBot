
using TelegramDataBase;

namespace BotTelegram
{
    public class learnRefKey
    {
        private ApplicationContext _db;

        public learnRefKey(ApplicationContext context) 
        {
            _db = context;
        }

        public learnRefKey() { }

        public string refKey(long idChat)
        {
            var user = _db.TelegramUsers.FirstOrDefault(x => x.IdChatTel == idChat);
            if (user == null)
            {
                return "Реферальный ключ отсутсвует";
            }
            return user.RefKey;
        }
    }
}
