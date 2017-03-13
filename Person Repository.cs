using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi1.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> Persons = new List<Person>();
        private int _nextId = 1;

        public PersonRepository()
        {
            Add(new Person { Id = 1, FirstName = "Peter", LastName = "Quinn", JobTytle = "Field Operations" });
            Add(new Person { Id = 2, FirstName = "Test", LastName = "Tester", JobTytle = "In House"});
        }

        public IEnumerable<Person> GetAll()
        {
            return Persons;
        }

        public Person Get(int id)
        {
            return Persons.Find(p => p.Id == id);
        }

        public Person Add(Person item)  
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            Persons.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Persons.RemoveAll(p => p.Id == id);
        }

        public bool Update(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Persons.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Persons.RemoveAt(index);
            Persons.Add(item);
            return true;
        }
    }
}