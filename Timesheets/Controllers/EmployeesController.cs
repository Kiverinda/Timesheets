using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : TimesheetsBaseController
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        /// <summary> Возвращает запись сотрудника </summary>
        
        [Authorize(Roles = "admin")]
        [HttpGet("employee/")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _employeeManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает все записи сотрудников </summary>
        
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }

        /// <summary> Создает запись сотрудника </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest employee)
        {
            var id = await _employeeManager.Create(employee);
            return Ok(id);
        }

        /// <summary> Обновляет запись сотрудника </summary>
        [Authorize(Roles = "admin")]
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] EmployeeRequest employee)
        {
            await _employeeManager.Update(id, employee);
            return Ok();
        }

        /// <summary> Обновляет запись сотрудника </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("delete/")]
        public async Task<IActionResult> Delete([FromQuery] Guid id, [FromBody] EmployeeRequest employee)
        {
            await _employeeManager.Delete(id, employee);
            return Ok();
        }
    }
}