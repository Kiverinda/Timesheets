using System;

namespace Timesheets.Models.Dto
{
    public sealed class RefreshTokenRequest
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}