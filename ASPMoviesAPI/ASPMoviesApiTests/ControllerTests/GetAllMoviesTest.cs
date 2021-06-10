using NUnit.Framework;
using FluentAssertions; 
using RESTAPI.Controllers;
using System.Linq; 
using RESTAPI.Models; 

namespace ASPMoviesApiTests.ControllerTests
{
    class GetAllMoviesTest
    {
        [Test]
        public void GetAllMoviesSimpleTest()
        {
            var context = new CodeFirstContext();
            var controller = new MainController(context);
            var result = controller.GetAllMovies();
            result.Value.Should().BeEquivalentTo(context.Movies.AsQueryable().ToList());
        }
    }
}
