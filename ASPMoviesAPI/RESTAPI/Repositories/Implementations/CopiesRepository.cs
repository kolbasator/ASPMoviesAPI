using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class CopiesRepository : Repository<Copy>
    { 
        public CopiesRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
