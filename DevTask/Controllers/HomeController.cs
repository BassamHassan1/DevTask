using DevTask.Models;
using DevTask.Models.Reposetories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Reporting.NETCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DevTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository<Customers> customerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CustomerContext _dbContext;

        // GET: HomeController1

        [Obsolete]
        public HomeController(CustomerContext dbContext, ICustomerRepository<Customers> customerRepository,IWebHostEnvironment webHostEnvironment)
        {
            //_hostingEnvironment = hostingEnvironment;
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
            this.customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var _Custlst = _dbContext.Customers.ToList();
            var g = _Custlst.AsEnumerable();
      
           
            return View(g.AsEnumerable());
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var customers = customerRepository.Find(id);

            return View(customers);
           }


        // GET: HomeController1/Create
        public ActionResult Create()
        {

            return View();
        }

        [Obsolete]
       

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
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = customerRepository.Find(id);
            return View(customer);
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
                    customerRepository.Update(id,customers);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "You have to fill requierd fields");
            return View("Index",customers);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = customerRepository.Find(id);
            return View(customer);
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
                return View();
            }
        }
        public ActionResult Search(string term)
        {
            var result = customerRepository.Search(term);

            return View("Index", result);
        }
    }
}
