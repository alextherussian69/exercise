using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi1.Models;

namespace TestApi1.Controllers
{
    public class PersonsController : ApiController
    {
        static readonly IPersonRepository repository = new PersonRepository();

        public IEnumerable<Person> GetAllPersons()
        {
            return repository.GetAll();
        }
        public Person GetPerson(int id)
        {
            Person item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public void PutPerson([FromBody]Person Person)
        {
            if (!repository.Update(Person))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Console.Write("Fname={0}, LNmae={1}, JobTytle={2}", Person.FirstName, Person.LastName, Person.JobTytle);
            }
        }
    }
}
