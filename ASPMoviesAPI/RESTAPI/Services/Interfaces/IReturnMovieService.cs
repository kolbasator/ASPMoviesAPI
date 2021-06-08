using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Services.Interfaces
{
    public interface IReturnMovieService
    {
        void ReturnMovie(int copyId, int clientId, DateTime dateOfRental); 
    }
}
