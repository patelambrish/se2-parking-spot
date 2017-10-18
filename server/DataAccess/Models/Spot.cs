using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Spot
    {
        public int Id { get; set; }
        public int? SpotNumber { get; set; }
        public string Lot { get; set; }
        public int? AssociateId { get; set; }
        public bool Reserved { get; set; }
        public string ReservedReason { get; set; }
        public bool IsManagerParking { get; set; }

        public virtual Associate Associate { get; set; }
    }
}
