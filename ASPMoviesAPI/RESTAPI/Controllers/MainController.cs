using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RESTAPI.Services.Interfaces;
using RESTAPI.Services.Implementations;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;
using AutoMapper;

namespace RESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private IMapper _mapper;
        private IRentMovieService _rentService;
        private IReturnMovieService _returnService;
        private MoviesRepository _moviesRepo;
        private ClientsRepository _clientsRepo;
        private RentalsRepository _rentalsRepo;
        private CopiesRepository _copiesRepo;

        public MainController(CodeFirstContext context, IRentMovieService _rent, IReturnMovieService _return, ClientsRepository clients, CopiesRepository copies, MoviesRepository movies, RentalsRepository rentals, IMapper mapper)
        {
            _moviesRepo = movies;
            _clientsRepo = clients;
            _rentalsRepo = rentals;
            _copiesRepo = copies;
            _rentService = _rent;
            _returnService = _return;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<MovieDTO> GetAllMovies()
        {
            var movies = _moviesRepo.GetAll();
            
            if (movies == null)
            {
                return BadRequest();
            }
            var result = _mapper.Map<List<MovieDTO>>(movies);
            return Ok(result);
        } 

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            _moviesRepo.Add(movie);
            _moviesRepo.SaveChanges();
            var result = _mapper.Map<MovieDTO>(movie);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult RentMovie(int movieId, int clientId)
        {
            Expression<Func<Movie, bool>> getMovie = i => i.MovieId == movieId;
            Expression<Func<Client, bool>> getClient = i => i.ClientId == clientId;
            var movie = _moviesRepo.Get(getMovie);
            var client = _clientsRepo.Get(getClient);
            if (movie == null && client == null)
            {
                return BadRequest();
            }
            _rentService.RentMovie(movieId, clientId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult ReturnMovie(int copyId, int clientId, DateTime dateOfRental)
        {
            Expression<Func<Copy, bool>> getCopy = i => i.CopyId == copyId;
            Expression<Func<Rental, bool>> getRental = i =>
                i.CopyId == copyId && i.ClientId == clientId && new DateTime(i.DateOfRental.Value.Year,
                    i.DateOfRental.Value.Month, i.DateOfRental.Value.Day, i.DateOfRental.Value.Hour,
                    i.DateOfRental.Value.Minute, i.DateOfRental.Value.Second) == dateOfRental;
            var copy = _copiesRepo.Get(getCopy);
            var rental = _rentalsRepo.Get(getRental);
            if (copy == null && rental == null)
            {
                return BadRequest();
            }
            _returnService.ReturnMovie(copyId, clientId, dateOfRental); 
            return Ok();
        }
    }
}