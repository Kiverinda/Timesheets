using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary> Возвращает запись пользователя </summary>
        [Authorize(Roles = "user")]
        [HttpGet("user/")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _userManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает все записи пользователей </summary>
        [Authorize(Roles = "admin")]
        [HttpGet("all/")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }

        /// <summary> Создает запись пользователя </summary>
        [Authorize(Roles = "admin")]
        [HttpPost("create/")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _userManager.Create(request);

            return Ok(response);
        }

        /// <summary> Обновляет запись пользователя </summary>
        [Authorize(Roles = "admin")]
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] UserRequest sheet)
        {
            await _userManager.Update(id, sheet);
            return Ok();
        }
    }
}