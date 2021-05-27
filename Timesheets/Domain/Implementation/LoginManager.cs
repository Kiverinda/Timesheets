﻿using System.Collections.Generic;
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
    public class LoginManager : ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;
        private readonly JwtRefreshOptions _jwtRefreshOptions;
        private readonly IRefreshTokenRepo _refreshTokenManager;

        public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions,
            IOptions<JwtRefreshOptions> jwtRefreshOptions,
            IRefreshTokenRepo refreshTokenRepo)
        {
            _jwtAccessOptions = jwtAccessOptions.Value;
            _jwtRefreshOptions = jwtRefreshOptions.Value;
            _refreshTokenManager = refreshTokenRepo;
        }

        public LoginResponse Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.Username),
                new(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);
            
            var refreshTokenRaw = _jwtRefreshOptions.GenerateToken(claims);
            var refreshToken = securityHandler.WriteToken(refreshTokenRaw);
            _refreshTokenManager.CreateOrUpdate(refreshToken, user);

            var loginResponse = new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime(),
            };

            return loginResponse;
        }
    }
}