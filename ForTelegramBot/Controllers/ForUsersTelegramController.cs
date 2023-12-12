using Microsoft.AspNetCore.Mvc;
using TelegramDataBase;
using TelegramDataBase.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ForTelegramBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForUsersTelegramController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public ForUsersTelegramController(ApplicationContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        [HttpPost] // Добавление пользователя в бд
        public async Task<ActionResult<ModelUser>> Post(ModelUser modelUser)
        {
            if (modelUser == null) { return BadRequest(); }
            if (_db.TelegramUsers.Any(x => x.FirstName == modelUser.FirstName)) { return BadRequest("Пользователь с таким именем уже существует!"); }

            User user = _mapper.Map<User>(modelUser);

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
