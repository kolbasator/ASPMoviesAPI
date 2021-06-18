using System;
using System.Collections.Generic;

#nullable disable

namespace RESTAPI.Models
{
    public partial class MovieDTO
    {
        public MovieDTO()
        { 
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int AgeRestriction { get; set; }
        public float Price { get; set; } 
    }
}
