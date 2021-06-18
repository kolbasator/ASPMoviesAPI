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
        private CodeFirstContext _context;
        private MoviesRepository _movies;
        private RentalsRepository _rentals;
        private ClientsRepository _clients;
        private CopiesRepository _copies;
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
        public RentMovieService(CodeFirstContext context,ClientsRepository clients,CopiesRepository copies,MoviesRepository movies,RentalsRepository rentals)
        {
            _context = context;
            _clients = clients;
            _copies = copies;
            _movies = movies;
            _rentals = rentals;
        }
    }
}
