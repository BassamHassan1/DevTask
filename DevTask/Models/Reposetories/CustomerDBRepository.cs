using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask.Models.Reposetories
{
    public class CustomerDBRepository : ICustomerRepository<Customers>
    {
        CustomerContext db;
        public CustomerDBRepository(CustomerContext _db)
        {
            db = _db;
        }
        public void Add(Customers entity)
        {
          
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = Find(id);

            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public Customers Find(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.id == id);

            return customer;
        }

        public IEnumerable<Customers> FindAll()
        {
            return db.Customers.AsEnumerable();
        }

        public IList<Customers> List()
        {
            return db.Customers.ToList();
        }

        public List<Customers> Search(string term)
        {
            var result = db.Customers.Where(c => c.CustomerFirstName.Contains(term)).ToList();

            return result;
        }


        public void Update(int id, Customers newCustomer)
        {
            db.Update(newCustomer);
            db.SaveChanges();
        }
    }
}
