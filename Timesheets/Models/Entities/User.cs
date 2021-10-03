using System;

namespace Timesheets.Models.Entities
{
    /// <summary> Информация о пользователе системы </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
    }
}