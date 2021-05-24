using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo : IRepoBase<User>
    {
        Task Delete(Guid id);
    }
}