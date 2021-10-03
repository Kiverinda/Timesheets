using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IRefreshTokenManager
    {
        void CreateOrUpdate(RefreshToken token);
    }
}