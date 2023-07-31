using DapperDemoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoData.Repository
{
    public interface IPersonRepository
    {
        Task<bool> AddPerson(Person person);
        Task<bool> UpdatePerson(Person person);
        Task<Person> GetPersonById(int id);
        Task<bool> DeletePerson(int id);
        Task<IEnumerable<Person>> GetPeople();
    }
}
