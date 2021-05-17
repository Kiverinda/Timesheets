using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class PersonController: ControllerBase
    {
        private readonly IPersonsManager _personsManager;
        
        public PersonController(IPersonsManager personsManager)
        {
            _personsManager = personsManager;
        }

        [HttpGet("id/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                Person person = _personsManager.GetItem(id);
                PersonDto result = new PersonDto()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Age = person.Age,
                    Company = person.Company
                };
                return Ok(result);
            }
            catch(System.NullReferenceException)
            {
                return NotFound("No Content");
            }
        }
        
        [HttpGet("searchTerm={term}")]
        public IActionResult GetItemByName([FromRoute] string term)
        {
            try
            {
                List<Person> persons = _personsManager.GetItemByName(term);
                if (persons == null) return NoContent();
                List<PersonDto> result = new List<PersonDto>();
                foreach (var person in persons)
                {
                    result.Add(new PersonDto()
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Company = person.Company,
                        Age = person.Age,
                        Email = person.Email
                    });
                }
                return Ok(result);
            }
            catch(System.NullReferenceException)
            {
                return NotFound("No Content");
            }
        }
        
        [HttpGet("skip={skip}&take={take}")]
        public IActionResult GetAll([FromRoute] int skip, [FromRoute] int take)
        {
            try
            {
                List<Person> persons = _personsManager.GetAll(skip, take);
                List<PersonDto> result = new List<PersonDto>();
                foreach (var person in persons)
                {
                    result.Add(new PersonDto()
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Company = person.Company,
                        Age = person.Age,
                        Email = person.Email
                    });
                }
                return Ok(result);
            }
            catch(System.NullReferenceException)
            {
                return NotFound("No Content");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonDto person)
        {
            var id = _personsManager.Create(person);
            return Ok(id);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            _personsManager.Update(person);
            return Ok();
        }
        
        [HttpDelete("id/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _personsManager.Delete(id);
            return Ok();
        }
    }
}