using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTAPI.Models;

namespace RESTAPI.Services.Interfaces
{
    public interface IRentMovieService
    {
        void RentMovie(int movieId,int clientId);
    }
}
