using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Simplex.Models;
using Simplex.Dto;
using AutoMapper;

namespace Simplex.Controllers.api
{
    public class CustomersController : ApiController
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

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customersDto = _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);

            if (customersDto!=null)
                return Ok(customersDto);
            return NotFound();

        }

        // GET: api/Customers/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var customerDto=Mapper.Map<CustomerDto>(customer);
            if (customer == null)
                return NotFound();
            return Ok(customerDto);
            

        }

        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult Post(Customer customer)
        {
            if (ModelState.IsValid&&customer!=null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Customers/5
        [HttpPut]
        public void Update(int id, Customer customer)
        {
            var customerInDb = _context.Customers.First(c=>c.Id==id);
            if (customerInDb == null)
                throw new Exception("customer not found");
            customerInDb.Lga = customer.Lga;
            customerInDb.PhoneNumber = customer.PhoneNumber;
            customerInDb.Address = customer.Address;
            _context.SaveChanges();


        }

        // DELETE: api/Customers/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
