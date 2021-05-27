using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IRefreshTokenRepo
    {
        Task<RefreshToken> GetItem(string tokenRow);
        Task CreateOrUpdate(string tokenRow, User user);
    }
}