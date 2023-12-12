using Microsoft.AspNetCore.Mvc;
using TelegramDataBase;
using TelegramDataBase.Models;

namespace ForTelegramBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForUsersTelegramController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public ForUsersTelegramController(ApplicationContext context)
        {
            _db = context;
        }

        [HttpPost] // Добавление пользователя в бд
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null) { return BadRequest(); }
            if (_db.TelegramUsers.Any(x => x.FirstName == user.FirstName)) { return BadRequest("Пользователь с таким именем уже существует!"); }
            _db.TelegramUsers.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }


        [HttpPut] // Изменение данных пользователя в соответсвие с именем пользователя, которое уникально
        public async Task <ActionResult<User>> Put(User user)
        {
            if (user == null) { return BadRequest(); }
            else if (!_db.TelegramUsers.Any(x => x.FirstName == user.FirstName)) { return NotFound("Пользователя с таким именем не существует!"); }
            _db.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

    }
}
