using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        //public string Spot { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ActivationKey  {get; set;}
    }
}
