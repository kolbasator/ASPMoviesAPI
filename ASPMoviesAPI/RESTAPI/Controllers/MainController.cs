using System;
using System.Linq.Expressions;
using RESTAPI.Services.Interfaces;
using RESTAPI.Services.Implementations;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;

namespace RESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IRentMovieService RentService { get; set; }
        private IReturnMovieService ReturnService { get; set; }
        private IRepository<Movie> MoviesRepo { get; set; }
        private IRepository<Client> ClientsRepo { get; set; }
        private IRepository<Rental> RentalsRepo { get; set; }
        private IRepository<Copy> CopiesRepo { get; set; }

        public MainController(CodeFirstContext context)
        {
            MoviesRepo = new Repository<Movie>(context);
            ClientsRepo = new Repository<Client>(context);
            RentalsRepo = new Repository<Rental>(context);
            CopiesRepo = new Repository<Copy>(context);
            RentService = new RentMovieService(context);
            ReturnService = new ReturnMovieService(context);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = MoviesRepo.GetAll();

            if (movies == null)
            {
                return BadRequest();
            }
            
            return Ok(movies);
        }

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            MoviesRepo.Add(movie);
            MoviesRepo.SaveChanges();
            return Ok(movie);
        }

        [HttpPut]
        public JsonResult RentMovie(int movieId, int clientId)
        {
            string success;
            Expression<Func<Movie, bool>> getMovie = i => i.MovieId == movieId;
            Expression<Func<Client, bool>> getClient = i => i.ClientId == clientId;
            var movie = MoviesRepo.Get(getMovie);
            var client = ClientsRepo.Get(getClient);
            
            if (movie != null && client != null)
            {
                success = "Movie was rented";
                RentService.RentMovie(movieId, clientId);
            }
            else
            {
                success = "Error";
            }

            return new JsonResult(success);
        }

        [HttpDelete]
        public IActionResult ReturnMovie(int copyId, int clientId, DateTime dateOfRental)
        {
            string success;
            Expression<Func<Copy, bool>> getCopy = i => i.CopyId == copyId;
            Expression<Func<Rental, bool>> getRental = i =>
                i.CopyId == copyId && i.ClientId == clientId && new DateTime(i.DateOfRental.Value.Year,
                    i.DateOfRental.Value.Month, i.DateOfRental.Value.Day, i.DateOfRental.Value.Hour,
                    i.DateOfRental.Value.Minute, i.DateOfRental.Value.Second) == dateOfRental;
            
            var copy = CopiesRepo.Get(getCopy);
            var rental = RentalsRepo.Get(getRental);
            
            if (copy != null && rental != null)
            {
                success = "Movie was returned";
                ReturnService.ReturnMovie(copyId, clientId, dateOfRental);
            }
            else
            {
                success = "Error";
            }

            return Ok(success);
        }
    }
}