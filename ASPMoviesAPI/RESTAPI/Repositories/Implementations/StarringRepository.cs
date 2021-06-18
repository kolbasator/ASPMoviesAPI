using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class StarringRepository : Repository<Starring>
    { 
        public StarringRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
