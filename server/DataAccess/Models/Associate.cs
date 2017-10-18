using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Associate
    {
        public Associate()
        {
            Spot = new HashSet<Spot>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsStallAssigned { get; set; }
        public bool? IsDowntownStall { get; set; }
        public string PreviousAssignedStall { get; set; }

        public virtual ICollection<Spot> Spot { get; set; }
    }
}
