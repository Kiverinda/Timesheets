using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IRefreshTokenManager
    {
        void CreateOrUpdate(RefreshToken token);
    }
}