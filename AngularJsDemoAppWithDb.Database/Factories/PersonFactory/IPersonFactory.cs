using AngularJsDemoAppWithDb.Database.Entities;
using AngularJsDemoAppWithDb.Dto.Person;

namespace AngularJsDemoAppWithDb.Database.Factories.PersonFactory
{
    public interface IPersonFactory
    {
        PersonDto CreatePerson(PersonEntity personEntity);
        PersonEntity CreatePerson(PersonDto personDto);
    }
}
