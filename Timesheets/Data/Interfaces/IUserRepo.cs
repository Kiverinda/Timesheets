using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo : IRepoBase<User>
    {
        Task Delete(Guid id);
        Task Create(User user);
        Task<User> GetByLoginAndPasswordHash(string requestLogin, byte[] passwordHash);
    }
}