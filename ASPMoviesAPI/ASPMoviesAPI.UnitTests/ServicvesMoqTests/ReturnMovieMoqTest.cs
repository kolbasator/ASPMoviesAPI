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
    public class ReturnMovieMoqTest
    {
        [Test]
        public void MoqReturnMovieTest()
        {
            //Expression<Func<Copy, bool>> getCopy = i => i.CopyId != 0;
            //Expression<Func<Rental, bool>> getRental = i => i.CopyId !=0 && i.ClientId != 0 && new DateTime(i.DateOfRental.Value.Year, i.DateOfRental.Value.Month, i.DateOfRental.Value.Day, i.DateOfRental.Value.Hour, i.DateOfRental.Value.Minute, i.DateOfRental.Value.Second) != null;
            //var context = new Mock<CodeFirstContext>(); 
            //var rentalsRepository = new Mock<RentalsRepository>(context.Object);
            //rentalsRepository.Setup(x => x.Get(getRental)).Returns(new Rental());
            //var copiesRepository = new Mock<CopiesRepository>(context.Object);
            //copiesRepository.Setup(c => c.Update(new Copy(),getCopy)).Returns(new Copy());
            //copiesRepository.Setup(c => c.Get(getCopy)).Returns(new Copy()); 
            //var rentService = new ReturnMovieService(context.Object,copiesRepository.Object,rentalsRepository.Object);
            //rentService.ReturnMovie(14,2,DateTime.Now);
        }
    }
}
