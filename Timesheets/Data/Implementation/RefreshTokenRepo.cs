using System;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class RefreshTokenRepo : IRefreshTokenRepo
    {
        private readonly TimesheetDbContext _context;

        public RefreshTokenRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        
        public async Task Add(RefreshToken token)
        {
            await _context.RefreshToken.AddAsync(token);
            await _context.SaveChangesAsync();
        }
        public async Task<RefreshToken> GetItem(Guid id)
        {
            var tokenFromBase = _context.RefreshToken.Find(id);
            return tokenFromBase;
        }

        public async Task Update(RefreshToken token)
        {
            _context.RefreshToken.Update(token);
            await _context.SaveChangesAsync();
        }
    }
}