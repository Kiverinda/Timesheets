using System.Collections.Generic;
using Timesheets.Models.Dto;
using Person = Timesheets.Models.Person;

namespace Timesheets.Domain.Interfaces
{
    public interface IPersonsManager
    {
        Person GetItem(int id);
        List<Person> GetItemByName(string name);
        List<Person> GetAll(int skip, int take);
        int Create(PersonDto item);
        void Update(Person item);
        void Delete(int id);
    }
}
