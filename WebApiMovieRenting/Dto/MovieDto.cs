using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApiMovieRenting.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfStocks { get; set; }
        public byte GenresId { get; set; }
    }
}