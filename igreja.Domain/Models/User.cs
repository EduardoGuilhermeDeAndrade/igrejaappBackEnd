﻿using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class User: EntityUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool IsResponsableMyTask { get; set; } = false;
    }
}

