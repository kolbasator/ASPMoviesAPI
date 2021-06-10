using NUnit.Framework;
using FluentAssertions;
using System;
using System.Linq;
using System.Linq.Expressions;
using RESTAPI.Data;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Services.Implementations;
using RESTAPI.Repositories.Implementations;
using RESTAPI.Models; 

namespace ASPMoviesApiTests
{
    public class ReturnMovieServiceTest
    {
        private static CodeFirstContext _context = new CodeFirstContext();  
        private static IRepository<Copy> _copies = new Repository<Copy>(_context); 
        private static IRepository<Rental> _rentals = new Repository<Rental>(_context);
        private static ReturnMovieService _returnService = new ReturnMovieService(_context);
        [Test]
        public void ReturnMovieSimpleTest()
        {  
            _returnService.ReturnMovie(7, 4,new DateTime(2021,6,9,16,30,28));
            var rental = _rentals.GetAll().FirstOrDefault(r => r.CopyId == 7 && r.ClientId == 4);
            rental.DateOfReturn.Should().Be(new DateTime(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            var copy = _copies.GetAll().FirstOrDefault(c => c.CopyId == 7);
            copy.Available.Should().Be(true);
        }
    }
}