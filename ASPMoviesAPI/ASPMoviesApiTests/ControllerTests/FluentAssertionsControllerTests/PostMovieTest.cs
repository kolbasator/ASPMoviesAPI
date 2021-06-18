using NUnit.Framework;
using FluentAssertions; 
using RESTAPI.Controllers;
using System.Linq;
using RESTAPI.Data;
using RESTAPI.Models; 

namespace ASPMoviesApiTests.ControllerTests
{
    class PostMovieTest
    {
        // [Test]
        // public void  PostMovieSimpleTest()
        // {
        //     var context = new CodeFirstContext();
        //     var controller = new MainController(context);
        //     var result = controller.Post(new Movie { MovieId = (context.Movies.Max(m => m.MovieId) + 1), Title = "Kolbasator", Year = 2021, AgeRestriction = 12, Price = 20.6f });
        //     result.Value.ToString().Should().Be("Post was successfully done");
        // }
    }
}
