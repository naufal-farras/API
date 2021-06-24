using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
     
        public PersonRepository(MyContext conn)
        {
            this.conn = conn;
        }

        public int Delete(int nik)
        {      
            Person person = null;
            person = conn.Persons.Find(nik);
            if (person != null)
            {
                conn.Remove(person);
                conn.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<Person> Get()
        {
            return conn.Persons.ToList();
        }

        public Person Get(int nik)
        {
            return conn.Persons.Find(nik);
        }

        public int Insert(Person person)
        {
            conn.Persons.Add(person);
            var result = conn.SaveChanges();
            return result;
        }

        public int Update(Person person)
        {
            int update = 0;
            if (person != null)
            {
                conn.Entry(person).State = EntityState.Modified;
                conn.SaveChanges();
                update = 1;
            }
            else
            {
                update = 0;
            }
            return update;
        }

       

    }
}
