using DapperDemoData.Data;
using DapperDemoData.Models;

namespace DapperDemoData.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDataAccess _db;
        public PersonRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddPerson(Person person)
        {
            try
            {
                string query = "insert into dbo.person(name,email) values(@Name,@Email)";
                await _db.SaveData(query, new { Name = person.Name, Email = person.Email });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                string query = "delete from dbo.person where id = @Id";
                await _db.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            string query = "select * from dbo.person";
            var people = await _db.GetData<Person, dynamic>(query, new { });
            return people;
        }

        public async Task<Person> GetPersonById(int id)
        {
            string query = "select * from dbo.person where id=@Id";
            IEnumerable<Person> people = await _db.GetData<Person, dynamic>(query, new { Id = id });
            return people.FirstOrDefault();
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            try
            {
                string query = "update dbo.person set name=@Name,email=@email where id=@Id";
                await _db.SaveData(query, person);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
