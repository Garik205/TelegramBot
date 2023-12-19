using System;
using TelegramDataBase;
using TelegramDataBase.Models;

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

        public string refKey(long id)
        {
            if (_db == null)
            {
                return "";
            }

            var user = _db.RegistrationUsers.First(c => c.IdChatTel == id);
            return user.ReferalKey;
        }
    }
}
