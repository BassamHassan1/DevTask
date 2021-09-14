using DevTask.Models;
using DevTask.Models.Reposetories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository<Customers> customerRepository;
        private readonly CustomerContext _dbContext;
        public CustomersController(ICustomerRepository<Customers> customerRepository, CustomerContext dbContext)
        {
            _dbContext = dbContext;
            this.customerRepository = customerRepository;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Get()
        {
            var result = customerRepository.FindAll();
            return Ok(result);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
       
        public IActionResult Index()
        {
            var _Custlst = _dbContext.Customers.ToList();
            var g = _Custlst.AsEnumerable();


            return Ok(g.AsEnumerable());
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var customers = customerRepository.Find(id);

            return Ok(customers);
                    }


        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return Ok();


        }

       

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers customers)
        {
            try
            {

                customerRepository.Add(customers);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = customerRepository.Find(id);
            return Ok(customer);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customers customers)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customerRepository.Update(id, customers);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return Ok();
                }
            }
            ModelState.AddModelError("", "You have to fill requierd fields");
            return Ok( customers);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = customerRepository.Find(id);
            return Ok(customer);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int id)
        {
            try
            {

                customerRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
        public ActionResult Search(string term)
        {
            var result = customerRepository.Search(term);

            return Ok(result);
        }
    }
}

