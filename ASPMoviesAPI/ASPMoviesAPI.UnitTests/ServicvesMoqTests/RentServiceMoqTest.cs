using NUnit.Framework;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RESTAPI.Data;
using AutoMapper;
using RESTAPI.Models;
using RESTAPI.Repositories.Implementations;
using RESTAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Services.Implementations;

namespace ASPMoviesAPI.UnitTests.ServicvesMoqTests
{
    public class RentServiceMoqTest
    {
        //[Test]
        //public void RentServiceMoqTets()
        //{ 
        //    Expression<Func<Movie, bool>> getMovie = i => i.MovieId != 0;
        //    Expression<Func<Client, bool>> getClient = i => i.ClientId != 0;
        //    Expression<Func<Copy, bool>> getAvailableCopy = i => i.MovieId !=0 && i.Available == true; 
        //    var context = new Mock<CodeFirstContext>();
        //    var clientsRepository = new Mock<ClientsRepository>(context.Object);
        //    clientsRepository.Setup(c => c.Get(getClient)).Returns(new Client()); 
        //    var rentalsRepository = new Mock<RentalsRepository>(context.Object);
        //    rentalsRepository.Setup(x => x.Add(new Rental())).Returns(new Rental());
        //    var copiesRepository = new Mock<CopiesRepository>(context.Object);
        //    copiesRepository.Setup(c => c.Update(new Copy(), getAvailableCopy)).Returns(new Copy());
        //    copiesRepository.Setup(c => c.Get(getAvailableCopy)).Returns(new Copy());
        //    var moviesRepository = new Mock<MoviesRepository>(context.Object);
        //    moviesRepository.Setup(m => m.Get(getMovie)).Returns(new Movie());
        //    var rentService = new RentMovieService(context.Object, clientsRepository.Object,copiesRepository.Object, moviesRepository.Object, rentalsRepository.Object);
        //    rentService.RentMovie(4, 3);

        //}
    }
}
