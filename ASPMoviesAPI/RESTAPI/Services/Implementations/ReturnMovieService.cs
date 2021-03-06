using System;
using System.Linq;
using System.Linq.Expressions;
using RESTAPI.Data;
using RESTAPI.Services.Interfaces;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;

namespace RESTAPI.Services.Implementations
{
    public class ReturnMovieService : IReturnMovieService
    {
        private readonly CodeFirstContext _context;
        private readonly RentalsRepository _rentals; 
        private readonly CopiesRepository _copies;
        public ReturnMovieService(CodeFirstContext context, CopiesRepository copies,RentalsRepository rentals)
        {
            _context = context;
            _copies = copies;
            _rentals = rentals;
        }
        public void ReturnMovie(int copyId, int clientId, DateTime dateOfRental)
        {
            Expression<Func<Copy, bool>> getCopy = i => i.CopyId == copyId;
            Expression<Func<Rental, bool>> getRental = i => i.CopyId == copyId && i.ClientId == clientId && new DateTime(i.DateOfRental.Value.Year, i.DateOfRental.Value.Month, i.DateOfRental.Value.Day, i.DateOfRental.Value.Hour, i.DateOfRental.Value.Minute, i.DateOfRental.Value.Second) == dateOfRental;
            var copy = _copies.Get(getCopy);
            var rental = _rentals.Get(getRental);
            if (copy != null && rental != null)
            {
                _copies.Update(new Copy { CopyId = copy.CopyId, Available = true, MovieId = copy.MovieId }, getCopy);
                var elementToUpdate = _context.Rentals.Where(r => r == rental).ToList();
                elementToUpdate.ElementAt(0).DateOfReturn = new DateTime(DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
            }
            _context.SaveChanges();
        }

    }
}
