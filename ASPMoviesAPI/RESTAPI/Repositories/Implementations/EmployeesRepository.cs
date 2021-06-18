using RESTAPI.Models;
using RESTAPI.Data;

namespace RESTAPI.Repositories.Implementations
{
    public class EmployeesRepository : Repository<Employee>
    { 
        public EmployeesRepository(CodeFirstContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
