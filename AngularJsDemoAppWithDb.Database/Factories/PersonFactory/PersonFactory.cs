using AngularJsDemoAppWithDb.Database.Entities;
using AngularJsDemoAppWithDb.Dto.Person;

namespace AngularJsDemoAppWithDb.Database.Factories.PersonFactory
{
    public class PersonFactory : IPersonFactory
    {
        public PersonDto CreatePerson(PersonEntity personEntity)
        {
            return new PersonDto
            {
                Age = personEntity.Age,
                Id = personEntity.Id,
                Name = personEntity.Name
            };
        }

        public PersonEntity CreatePerson(PersonDto personDto)
        {
            return new PersonEntity
            {
                Age = personDto.Age,
                Id = personDto.Id,
                Name = personDto.Name
            };
        }
    }
}
