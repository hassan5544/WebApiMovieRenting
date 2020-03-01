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
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movie
        [HttpGet]
        public IHttpActionResult GetMovies(string Name = "", string sort = "Name", string sortdir = "asc", int pageSize = 4, int page = 1)
        {
            var movieQuery = (from a in _context.Movies.Include(c => c.Genres)
                              where
                              a.Name.Contains(Name)
                              select a);

            movieQuery = movieQuery.OrderBy(sort + " " + sortdir);
            if (page == 0)
                page = 1;
            int skip = (page * pageSize) - pageSize;

            if (pageSize > 0)
            {
                movieQuery = movieQuery.Skip(skip).Take(pageSize);
            }

            var movieDto = movieQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        [HttpGet]
        //GET api/movie/id
        public IHttpActionResult GetMovieId(int id )

        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        // POST api/movie
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/movie/id
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);


            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int id)

        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }
    }
    
}
