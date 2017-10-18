using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AuthToken
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string AccessCode { get; set; }
        public bool IsUsed { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
