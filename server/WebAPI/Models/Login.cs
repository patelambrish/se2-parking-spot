using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Login
    {
      public string EmailAddress { get; set; }
      public string AccessCode { get; set; }
    }
}
