using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        Task<Guid> Create(CreateUserRequest user);
        Task Update(Guid id, UserRequest userRequest);
        Task<User> GetUser(LoginRequest request);
    }
}