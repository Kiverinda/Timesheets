using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return await _employeeRepo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _employeeRepo.GetItems();
        }

        public async Task<Guid> Create(EmployeeRequest employeeRequest)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                UserId = employeeRequest.UserId
            };
            await _employeeRepo.Add(employee);

            return employee.Id;
        }

        public async Task Update(Guid id, EmployeeRequest employeeRequest)
        {
            var employee = new Employee
            {
                Id = id,
                UserId = employeeRequest.UserId
            };
            await _employeeRepo.Update(employee);
        }

        public async Task Delete(Guid id, EmployeeRequest employeeRequest)
        {
            var employee = new Employee
            {
                Id = id,
                UserId = employeeRequest.UserId,
                IsDeleted = true
            };
            await _employeeRepo.Update(employee);
        }
    }
}