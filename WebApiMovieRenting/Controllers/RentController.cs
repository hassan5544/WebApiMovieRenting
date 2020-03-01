using System;
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
    public class RentController : ApiController
    {
        private ApplicationDbContext _context;
        public RentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult addRent (RentDto rentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var rent = Mapper.Map<RentDto, Rent>(rentDto);
            var movie = _context.Movies.SingleOrDefault(c => c.Id == rent.MovieId);
            movie.NumberOfStocks--; 


            _context.Rent.Add(rent);
            _context.SaveChanges();

            rentDto.Id = rent.Id;
            return Created(new Uri(Request.RequestUri + "/" + rent.Id), rentDto);
        }
        [HttpGet]
        public IHttpActionResult GetRents(string sort = "rentDate" , string sortdir = "asc" )
        {
            var RentQuery = (from a in _context.Rent.Include(c => c.Customer)
                              select a);

            RentQuery = RentQuery.OrderBy(sort + " " + sortdir);
           

            var rentDto = RentQuery.ToList().Select(Mapper.Map<Rent, RentDto>);

            return Ok(rentDto);
        }

        [HttpPut]

        public void returnMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var rendDb = _context.Rent.SingleOrDefault(c => c.Id == id);

            if (rendDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            if (rendDb.Statuas == false)
            {
                rendDb.Statuas = true;
                var movie = _context.Movies.SingleOrDefault(c => c.Id == rendDb.Id);
                movie.NumberOfStocks++;

                _context.SaveChanges();

            }

        }

    }

    

    }

