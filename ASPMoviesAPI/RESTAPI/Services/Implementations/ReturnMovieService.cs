using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Services.Interfaces;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;

namespace RESTAPI.Services.Implementations
{
    public class ReturnMovieService : IReturnMovieService
    {
        private CodeFirstContext _context { get; set; }
        private IRepository<Rental> _rentals { get; set; }
        private IRepository<Copy> _copies { get; set; }
        public void ReturnMovie(int copyId, int clientId, DateTime dateOfRental)
        {
            Expression<Func<Copy, bool>> getCopy = i => i.CopyId == copyId;
            Expression<Func<Rental, bool>> getRental = i => i.CopyId == copyId && i.ClientId == clientId && i.DateOfRental == dateOfRental;
            var copy = _copies.Get(getCopy);
            var rental = _rentals.Get(getRental);
            if (copy != null && rental != null)
            {
                _copies.Put(new Copy { CopyId = copy.CopyId,Available=true,MovieId=copy.MovieId },getCopy);
                _rentals.Put(new Rental { CopyId = rental.CopyId, ClientId = rental.ClientId, DateOfRental = rental.DateOfRental, DateOfReturn = DateTime.Now }, getRental);
            }
            _context.SaveChanges(); 
        }
        public ReturnMovieService(CodeFirstContext context)
        {
            _context = context; 
            _copies = new Repository<Copy>(_context); 
            _rentals = new Repository<Rental>(_context);
        }
    }
}
