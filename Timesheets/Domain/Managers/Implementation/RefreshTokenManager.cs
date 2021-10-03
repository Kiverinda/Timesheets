using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Implementation
{
    public class RefreshTokenManager : IRefreshTokenManager
    {
        private readonly IRefreshTokenRepo _refreshTokenRepo;

        public RefreshTokenManager(IRefreshTokenRepo refreshTokenRepo)
        {
            _refreshTokenRepo = refreshTokenRepo;
        }
        public async void CreateOrUpdate(RefreshToken token)
        {
            var tokenFromBase = await _refreshTokenRepo.GetItem(token.UserId);
            if (tokenFromBase.Token == null)
            {
                await _refreshTokenRepo.Add(token);
            }
            else
            {
                await _refreshTokenRepo.Update(token);
            }
        }
    }
}