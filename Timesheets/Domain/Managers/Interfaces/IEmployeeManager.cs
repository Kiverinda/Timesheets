using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<IEnumerable<Employee>> GetItems();
        Task<Guid> Create(EmployeeRequest employee);
        Task Update(Guid id, EmployeeRequest employeeRequest);
        Task Delete(Guid id, EmployeeRequest employeeRequest);
    }
}