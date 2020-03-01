using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using WebApiMovieRenting.Models;
using WebApiMovieRenting.Dto;
using AutoMapper;
namespace WebApiMovieRenting.Controllers.api
{

    public class CustomersController : ApiController
    {


        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/customers
        public IHttpActionResult GetCustomers(string Name = "",string sort ="Name", string sortdir="asc" ,int pageSize =4  ,int page=1)
        {
            var custoemrsQury = (from a in _context.customers.Include(c=> c.MemberShipType) where
                                 a.Name.Contains(Name) select a);

            custoemrsQury = custoemrsQury.OrderBy(sort + " " + sortdir);
            if (page == 0)
                page = 1;
            int skip = (page * pageSize) - pageSize;

            if (pageSize > 0)
            {
                custoemrsQury = custoemrsQury.Skip(skip).Take(pageSize);
            }

            var custoemrDto = custoemrsQury.ToList().Select(Mapper.Map<Customers, CustomerDto>);

            return Ok(custoemrDto);
        }
        // GET api/Customers/1
        public IHttpActionResult GetCustomer(int id )
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok( Mapper.Map<Customers,CustomerDto>(customer));
        }

        // POST /api/customers 
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customers>(customerDto);
            _context.customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }


        // PUT /api/customers/1
        [HttpPut]
        public void  UpdateCustomer(int id ,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CustomerInDb = _context.customers.SingleOrDefault(c => c.Id == id);

            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, CustomerInDb);


            _context.SaveChanges();

        }

        // DELETE api/customers/1
        [HttpDelete ]
        public void DelteCustomer (int id)

        {
            var CustomerInDb = _context.customers.SingleOrDefault(c => c.Id == id);

            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.customers.Remove(CustomerInDb);
            _context.SaveChanges();

        }
    }
}
