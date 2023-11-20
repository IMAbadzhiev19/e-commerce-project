﻿namespace WebApp.ModelView
{
    public class UserMV
    {
        public string? UserName { get; set; }

        public string? Email { get; set; } 
        
        public string? PasswordHash { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Password;
    }
}