using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ClientRepo : IClientRepo
    {
        public Task<Client> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Add(Client item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}

