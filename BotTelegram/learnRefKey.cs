using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using TelegramDataBase;
using TelegramDataBase.Models;

namespace BotTelegram
{
    public class learnRefKey
    {
        private ApplicationContext _db;
        public learnRefKey(DbContextOptions<ApplicationContext> options) 
        {
            _db = new ApplicationContext(options);
        }
        public learnRefKey() 
        {
            _db = new ApplicationContext();
        }

        public string refKey(long id)
        {

            //var user = _db.RegistrationUsers.FirstOrDefault(c => c.IdChatTel == id);
            //if (user == null)
            //{
            //    return "";
            //}
            //return user.ReferalKey;

            using (var context = new ApplicationContext())
            {
                var ctxUser = context.RegistrationUsers.FirstOrDefault(_ => _.IdChatTel == id);
                    
                if (ctxUser == null)
                    return "Error 404";
                return ctxUser.ReferalKey;
            }
        }
    }
}
