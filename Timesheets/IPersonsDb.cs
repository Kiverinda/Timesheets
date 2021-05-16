using System.Collections.Generic;
using Timesheets.Models;

namespace Timesheets
{
    public interface IPersonsDb
    {
        List<Person> Persons { get; set; }
        int GetCount();
    }
}