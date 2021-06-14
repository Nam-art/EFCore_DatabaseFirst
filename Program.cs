using EFCore_DatabaseFirst.Db;
using System;
using System.Linq;

namespace EFCore_DatabaseFirst
{
    class Program
    {
        static readonly DbFirstDemoContext _dbContext = new DbFirstDemoContext();

        static int GetRecordCount()
        {
            return _dbContext.People.ToList().Count;
        }
        static void AddRecord()
        {
            var person = new Person { FirstName = "Vjor", LastName = "Durano", DateOfBirth = Convert.ToDateTime("6/19/2020") };
            _dbContext.Add(person);
            _dbContext.SaveChanges();
        }
        static void UpdateRecord(int id)
        {
            var person = _dbContext.People.Find(id);
            if(person == null)
            {
                return;
            }
            person.FirstName = "Vynn Markus";
            person.DateOfBirth = Convert.ToDateTime("11/22/2016");
            _dbContext.Update(person);
            _dbContext.SaveChanges();
        }
        static Person GetRecord(int id)
        {
            return _dbContext.People.SingleOrDefault(p => p.Id.Equals(id));
        }
        static void DeleteRecord(int id)
        {
            var person = _dbContext.People.Find(id);
            if (person == null)
            {
                return;
            }
            _dbContext.Remove(person);
            _dbContext.SaveChanges();
        }
        static void Main(string[] args)
        {
            DeleteRecord(1);
            Console.WriteLine($"Record Count: {GetRecordCount()}");
        }

    }
}
