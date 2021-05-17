using System.Collections.Generic;
using System.Linq;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class PersonRepo: IPersonRepo
    {
        private readonly IPersonsDb _persons;

        public PersonRepo(IPersonsDb persons)
        {
            _persons = persons;
        }

        public int GetCount()
        {
            return _persons.GetCount();
        }
        public Person GetItem(int id)
        {
            return _persons.Persons.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetItemByName(string name)
        {
            return from person in _persons.Persons where person.FirstName==name select person;
        }

        public IEnumerable<Person> GetItems(int skip, int take)
        {
            return _persons.Persons.Skip(skip).Take(take);
        }

        public void Create(Person item)
        {
            _persons.Persons.Add(item);
        }
        public void Update(Person item)
        {
            var person = _persons.Persons.FirstOrDefault(x => x.Id == item.Id);
            if (person == null) return;
            person.Age = item.Age;
            person.Company = item.Company;
            person.Email = item.Email;
            person.FirstName = item.FirstName;
            person.LastName = item.LastName;
        }

        public void Delete(int id)
        {
            var person = _persons.Persons.FirstOrDefault(x => x.Id == id);
            _persons.Persons.Remove(person);
        }
    }
}