using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApiMovieRenting.Models;
using WebApiMovieRenting.Dto;
namespace WebApiMovieRenting.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customers>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Rent, RentDto>();
            Mapper.CreateMap<RentDto, Rent>();
        }
    }
}