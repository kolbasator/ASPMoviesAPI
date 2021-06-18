using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class RentalsRepository : Repository<Rental>
    { 
        public RentalsRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
