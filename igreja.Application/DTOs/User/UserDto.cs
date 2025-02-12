﻿namespace igreja.Application.DTOs
{
    public class UserDto 
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsResponsableMyTask { get; set; } = false;
    }
}

