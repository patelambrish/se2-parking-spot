using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Account {

        public int Id { get; set; }
        [Required(ErrorMessage="Email Address is required.")]
        [RegularExpression(@"([a-zA-Z][\w\.-]*[a-zA-Z0-9])@(securitybenefit.com|se2.com)", ErrorMessage="Email Address is invalid.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]        
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }        
        public string Spot { get; set; }
        public bool IsActive { get; set; }

    }
}