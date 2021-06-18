using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class ActorsRepository : Repository<Actor>
    { 
        public ActorsRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
