using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask.Models.Reposetories
{
    public class CustomerRepository : ICustomerRepository<Customers>
    {
        public CustomerContext CustomerContext { get; set; }
 
        public CustomerRepository(CustomerContext customerContext)
        {
            CustomerContext = customerContext;
        }

        public void Add(Customers entity)
        {
            CustomerContext.Customers.Add(entity);
            CustomerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = Find(id);

            CustomerContext.Customers.Remove(customer);
            CustomerContext.SaveChanges();

        }

        public Customers Find(int id)
        {
            var customer = CustomerContext.Customers.FirstOrDefault(c => c.id == id);

            return customer;
        }

        public IEnumerable<Customers> FindAll()
        {
            return CustomerContext.Customers.AsEnumerable();
        }

        public IList<Customers> List()
        {
            return CustomerContext.Customers.ToList();
        }

        public List<Customers> Search(string term)
        {
            return CustomerContext.Customers.Where(c => c.CustomerFirstName.Contains(term)).ToList();
        }
        public void Update(int id, Customers newCustomer)
        {

            using(var context = CustomerContext)
            {

                var customer = CustomerContext.Customers
                    .FirstOrDefault(c => c.id == id);


                customer.CustomerFirstName = newCustomer.CustomerFirstName;
                customer.CustomerLastName = newCustomer.CustomerLastName;
                customer.CustomerGender = newCustomer.CustomerGender;
                customer.CustomerDOB = newCustomer.CustomerDOB;
                customer.CustomerEmail = newCustomer.CustomerEmail;

                CustomerContext.Customers.Update(customer);
                CustomerContext.SaveChanges();
            }

        }
    }
}
