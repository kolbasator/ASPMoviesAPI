using System;
using System.Collections.Generic;

#nullable disable

namespace RESTAPI.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Starrings = new HashSet<Starring>();
        }

        public int ActorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Starring> Starrings { get; set; }
    }
}
