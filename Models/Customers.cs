﻿namespace Models
{
    public class Customers
    {
        public Customers(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}