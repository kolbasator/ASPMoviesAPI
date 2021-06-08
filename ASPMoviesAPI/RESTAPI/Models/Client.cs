using System;
using System.Collections.Generic;

#nullable disable

namespace RESTAPI.Models
{
    public partial class Client
    {
        public Client()
        {
            Rentals = new HashSet<Rental>();
        }

        public int ClientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
