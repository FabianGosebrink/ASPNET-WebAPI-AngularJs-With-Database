using System.Linq;
using AngularJsDemoAppWithDb.Database.Entities;

namespace AngularJsDemoAppWithDb.Database.Repositories.PersonRepository
{
    public interface IPersonRepository
    {
        IQueryable<PersonEntity> GetPersons();
        PersonEntity GetPerson(int id);
        int DeletePerson(int id);
        int InsertPerson(PersonEntity person);
    }
}