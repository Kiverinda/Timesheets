﻿using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IRefreshTokenRepo
    {
        Task<RefreshToken> GetItem(Guid id);
        Task Update(RefreshToken tokenRow);
        
        Task Add(RefreshToken tokenRow);
    }
}