
using System.Linq;
using AngularJsDemoAppWithDb.Database.Context;
using AngularJsDemoAppWithDb.Database.Entities;

namespace AngularJsDemoAppWithDb.Database.Repositories.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DemoAppContext _demoAppContext;

        public PersonRepository(DemoAppContext demoAppContext)
        {
            _demoAppContext = demoAppContext;
        }

        public IQueryable<PersonEntity> GetPersons()
        {
            return _demoAppContext.Person;
        }

        public PersonEntity GetPerson(int id)
        {
            return _demoAppContext.Person.FirstOrDefault(x => x.Id == id);
        }

        public int DeletePerson(int id)
        {
            PersonEntity personEntity = GetPerson(id);

            _demoAppContext.Person.Remove(personEntity);
            return _demoAppContext.SaveChanges();
        }

        public int InsertPerson(PersonEntity person)
        {
            _demoAppContext.Person.Add(person);
            return _demoAppContext.SaveChanges();
        }
    }
}
