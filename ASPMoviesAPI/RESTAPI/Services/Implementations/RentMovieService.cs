using System; 
using System.Linq.Expressions;
using RESTAPI.Data;
using RESTAPI.Services.Interfaces;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;

namespace RESTAPI.Services.Implementations
{
    public class RentMovieService : IRentMovieService
    {
        private CodeFirstContext _context { get; set; }
        private IRepository<Movie> _movies { get; set; }
        private IRepository<Rental> _rentals { get; set; }
        private IRepository<Client> _clients { get; set; }
        private IRepository<Copy> _copies { get; set; }
        public void RentMovie(int movieId, int clientId)
        {
            Expression<Func<Movie, bool>> getMovie = i => i.MovieId == movieId;
            Expression<Func<Client, bool>> getClient = i => i.ClientId == clientId;
            var movie = _movies.Get(getMovie);
            var client = _clients.Get(getClient);
            if (movie != null && client != null)
            {
                Expression<Func<Copy, bool>> getAvailableCopy = i => i.MovieId == movie.MovieId && i.Available == true;
                var copy = _copies.Get(getAvailableCopy);
                if (copy != null)
                {
                    _copies.Update(new Copy { CopyId = copy.CopyId, Available = false, MovieId = copy.MovieId },getAvailableCopy);
                    var newRental = new Rental { CopyId = copy.CopyId, ClientId = client.ClientId, DateOfRental = DateTime.Now, DateOfReturn = null };
                    _rentals.Add(newRental);
                }
            }
            _context.SaveChanges();
        }
        public RentMovieService(CodeFirstContext context)
        {
            _context = context;
            _clients = new Repository<Client>(_context);
            _copies = new Repository<Copy>(_context);
            _movies = new Repository<Movie>(_context);
            _rentals = new Repository<Rental>(_context);
        }
    }
}
