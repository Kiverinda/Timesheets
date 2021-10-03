using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IRefreshTokenRepo
    {
        Task<RefreshToken> GetItem(Guid id);
        Task Update(RefreshToken tokenRow);
        
        Task Add(RefreshToken tokenRow);
    }
}