using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using AngularJsDemoAppWithDb.Database.Context;
using AngularJsDemoAppWithDb.Database.Entities;
using AngularJsDemoAppWithDb.Database.Factories.PersonFactory;
using AngularJsDemoAppWithDb.Database.Repositories.PersonRepository;
using AngularJsDemoAppWithDb.Dto.Person;

namespace AngularJsDemoAppWithDb.Controllers
{
    [RoutePrefix("api")]
    public class PeopleController : ApiController
    {
        readonly IPersonRepository _repository;
        readonly IPersonFactory _personFactory = new PersonFactory();

        public PeopleController()
        {
            _repository = new PersonRepository(new DemoAppContext());
        }

        [Route("peoples")]
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<PersonEntity> persons = _repository.GetPersons();

                var result = persons.ToList().Select(eg => _personFactory.CreatePerson(eg));

                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("peoples/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                PersonEntity personEntity = _repository.GetPerson(id);

                if (personEntity == null)
                {
                    return NotFound();
                }

                _repository.DeletePerson(id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("peoples")]
        public IHttpActionResult Post([FromBody]PersonDto personDto)
        {
            try
            {
                if (personDto == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                PersonEntity person = _personFactory.CreatePerson(personDto);

                int result = _repository.InsertPerson(person);

                if (result > 0)
                {
                    PersonDto newPerson = _personFactory.CreatePerson(person);
                    return Created<PersonDto>(Request.RequestUri + "/" + newPerson.Id, newPerson);
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
