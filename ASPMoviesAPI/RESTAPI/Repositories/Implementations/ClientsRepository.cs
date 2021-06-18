using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class ClientsRepository : Repository<Client>
    { 
        public ClientsRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
