using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IEmployeeRepo : IRepoBase<Employee>
    {
        Task Delete(Guid id);
    }
}