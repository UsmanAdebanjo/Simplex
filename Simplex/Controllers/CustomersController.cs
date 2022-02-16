using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simplex.Models;

namespace Simplex.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cusstomers
        [Authorize]
        public ActionResult Index()
        {
            var customers=_context.Customers.ToList();
            return View("Index",customers);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer )
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            else
                _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var customerInDb=_context.Customers.Single(c => c.Id == id);

            if (customerInDb != null)
            {
                
                return View("Create", "customerInDb");
            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult Details(int id)
        {
            var customerInDb = _context.Customers.Single(c=>c.Id==id);

            return PartialView("Details",customerInDb);
        }

        [Authorize(Roles ="CanManageCustomers")]
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);
            if (customerInDb != null)
            {
                _context.Customers.Remove(customerInDb);
            }
            else
            {
                return HttpNotFound();
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

            
        }
    }
}