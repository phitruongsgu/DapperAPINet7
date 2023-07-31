using DapperDemoData.Models;
using DapperDemoData.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _personRepository.GetPeople();
            return Ok(people);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personRepository.GetPersonById(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _personRepository.AddPerson(person);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person updatePerson)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var person = await _personRepository.GetPersonById(id);
            if (person == null)
                return NotFound();


            updatePerson.Id = id;
            var result = await _personRepository.UpdatePerson(updatePerson);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personRepository.GetPersonById(id);
            if (person == null)
                return NotFound();
            var result = await _personRepository.DeletePerson(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }
    }
}
