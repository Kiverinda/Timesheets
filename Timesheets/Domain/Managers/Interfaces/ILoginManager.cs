using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface ILoginManager
    {
        LoginResponse Authenticate(User user);
    }
}