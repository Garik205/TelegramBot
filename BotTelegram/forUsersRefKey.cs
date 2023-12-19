using TelegramDataBase;
using TelegramDataBase.Models;

namespace BotTelegram
{
    public class forUsersRefKey
    {
        private ApplicationContext _db;
        public forUsersRefKey(ApplicationContext context) { _db = context; }
        public forUsersRefKey() { }

        public List<User> printUsers(long id)
        {
            var refkey = _db.RegistrationUsers.FirstOrDefault(x => x.IdChatTel == id);
            var listuser = _db.RegistrationUsers.Where(c => c.CheckRefKey == refkey.ReferalKey).ToList();
            return listuser;
        }
    }
}
