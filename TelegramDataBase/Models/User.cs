﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TelegramDataBase.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public long IdChatTel { get; set; }
        
        public string RefKey { get; set; } = Guid.NewGuid().ToString();
    }
}
