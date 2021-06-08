using System;
using System.Linq.Expressions;
using RESTAPI.Services.Interfaces;
using RESTAPI.Services.Implementations;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication16667.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IRentMovieService _rentService { get; set; }
        private IReturnMovieService _returnService { get; set; }
        private IRepository<Movie> _movies { get; set; }
        private IRepository<Client> _clients { get; set; }
        private IRepository<Rental> _rentals{ get; set; }
        private IRepository<Copy> _copies { get; set; }
        public MainController(CodeFirstContext context)
        {
            _movies = new Repository<Movie>(context);
            _clients = new Repository<Client>(context);
            _rentals = new Repository<Rental>(context);
            _copies = new Repository<Copy>(context);
            _rentService = new RentMovieService(context);
            _returnService = new ReturnMovieService(context);
        }

        [HttpGet]
        public JsonResult GetAllMovies()
        {
            return new JsonResult(_movies.GetAll());
        }

        [HttpPost]
        public JsonResult Post(Movie movie)
        {
            _movies.Post(movie);
            return new JsonResult("Post was successfully done");
        }

        [HttpPut]
        public JsonResult RentMovie(int movieId, int clientId)
        {
            string success;
            Expression<Func<Movie, bool>> getMovie = i => i.MovieId == movieId;
            Expression<Func<Client, bool>> getClient = i => i.ClientId == clientId;
            var movie = _movies.Get(getMovie);
            var client = _clients.Get(getClient);
            if (movie != null && client != null)
            {
                success = "Movie was rented";
                _rentService.RentMovie(movieId, clientId);
            }
            else
            {
                success = "Error";
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult ReturnMovie(int copyId, int clientId, DateTime dateOfRental)
        {
            string success;
            Expression<Func<Copy, bool>> getCopy = i => i.CopyId == copyId;
            Expression<Func<Rental, bool>> getRental = i => i.CopyId == copyId && i.ClientId == clientId && i.DateOfRental == dateOfRental;
            var copy = _copies.Get(getCopy);
            var rental = _rentals.Get(getRental);
            if (copy != null && rental != null)
            {
                success = "Movie was returned";
                _returnService.ReturnMovie(copyId,clientId,dateOfRental);
            }
            else
            {
                success = "Error";
            }
            return new JsonResult(success);
        }
    }
}
