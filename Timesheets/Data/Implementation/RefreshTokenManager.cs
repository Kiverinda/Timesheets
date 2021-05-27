using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class RefreshTokenRepo : IRefreshTokenRepo
    {
        public Task<RefreshToken> GetItem(string tokenRow)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateOrUpdate(string tokenRow, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}