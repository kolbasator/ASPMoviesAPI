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
using RESTAPI.Services.Interfaces;

namespace ASPMoviesAPI.UnitTests
{
    public class ControllerGetMoqTest
    { 

        //[Test]
        //public void MoqControllerGetTest()
        //{
        //    var context = new Mock<CodeFirstContext>();
        //    var clientsRepository = new Mock<ClientsRepository>(context.Object);
        //    var rentalsRepository = new Mock<RentalsRepository>(context.Object);
        //    var copiesRepository = new Mock<CopiesRepository>(context.Object);
        //    var moviesRepository = new Mock<MoviesRepository>(context.Object);
        //    moviesRepository.Setup(m => m.GetAll()).Returns(new List<Movie>());
        //    var rentService = new Mock<IRentMovieService>();
        //    var returnService = new Mock<IReturnMovieService>();
        //    var mapper = new Mock<IMapper>();
        //    mapper.Setup(m => m.Map<List<MovieDTO>>(new List<Movie>())).Returns(new List<MovieDTO>());
        //    var controller = new MainController(context.Object, rentService.Object, returnService.Object, clientsRepository.Object, copiesRepository.Object, moviesRepository.Object, rentalsRepository.Object, mapper.Object);
        //    var result = controller.GetAllMovies();
        //    (result.Result as OkObjectResult).StatusCode.Should().Be(200);
        //}
    }
}