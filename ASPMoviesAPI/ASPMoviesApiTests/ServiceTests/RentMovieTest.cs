using NUnit.Framework;
using FluentAssertions;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Services.Implementations;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;
using RESTAPI.Models;
using RESTAPI.Services.Interfaces;

namespace ASPMoviesApiTests
{
    public class RentMovieServiceTest
    {
        private static CodeFirstContext _context = new CodeFirstContext();
        private static IRentMovieService _rentService = new RentMovieService(_context);
        private static IRepository<Movie> _movies = new Repository<Movie>(_context);
        private static IRepository<Client> _clients = new Repository<Client>(_context);
        private static IRepository<Rental> _rental = new Repository<Rental>(_context);
        [Test]
        public void RentMovieSimpleTest()
        { 
            //var oldCount = _rental.GetAll().Count(); 
            //_rentService.RentMovie(4, 4);
            //var newCount = _rental.GetAll().Count();
            //var check = (oldCount + 1) == newCount; 
            //check.Should().Be(true);
        }
    }
}