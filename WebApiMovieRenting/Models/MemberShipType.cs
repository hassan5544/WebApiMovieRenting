using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMovieRenting.Models
{
    public class MemberShipType
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int DiscountRate { get; set; }

    }
}