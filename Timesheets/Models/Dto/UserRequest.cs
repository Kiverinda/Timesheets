namespace Timesheets.Models.Dto
{
    public class UserRequest
    {
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}