using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class MoviesRepository : Repository<Movie>
    { 
        public MoviesRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
