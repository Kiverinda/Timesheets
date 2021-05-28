using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Domain.Implementation
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