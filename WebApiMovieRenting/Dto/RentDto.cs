using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovieRenting;
namespace WebApiMovieRenting.Dto
{
    public class RentDto
    {
        public int Id { get; set; }
        public int customerId { get; set; }

        public int MovieId { get; set; }

        public DateTime RentDate { get; set; }

        public bool Statuas { get; set; }
    }
}