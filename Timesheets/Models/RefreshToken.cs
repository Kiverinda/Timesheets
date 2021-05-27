using System;

namespace Timesheets.Models
{
    /// <summary> Refresh Token пользователей </summary>
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}