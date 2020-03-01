using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApiMovieRenting.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public Customers Customer { get; set; }
        public int customerId { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }

        public DateTime RentDate { get; set; }

        public bool Statuas { get; set; }
    }
}