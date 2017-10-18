using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
  public class AuthController: Controller
  {
    private IEmailRepository _emailRepo;
    private spot2shareContext _dbContext;
    public AuthController(IEmailRepository emailRepo, spot2shareContext dbContext)
    {
      _emailRepo = emailRepo;
      _dbContext = dbContext;
    }

    [HttpPost]
    [Route("api/[controller]")]
    public IActionResult Post([FromBody]Auth auth)
    {

        Registration reg = _dbContext.Registration.Where(r => r.EmailAddress.Equals(auth.EmailAddress,StringComparison.CurrentCultureIgnoreCase) && r.MobileNumber.Equals(auth.MobileNumber,StringComparison.CurrentCultureIgnoreCase) && r.IsActive).FirstOrDefault();
ReturnResponse res = new ReturnResponse();
        if(reg!=null) {
AuthToken item =new AuthToken();
item.EmailAddress =reg.EmailAddress;
item.IsUsed = false;
item.AccessCode =this.RandomString(6);
item.UpdateDate = DateTime.Now;
_dbContext.AuthToken.Add(item);
_dbContext.SaveChanges();
res.success = true;
res.message = "Email has been sent with Access Code for login";
_emailRepo.SendEmail("ambrish.patel@se2.com",reg.EmailAddress,String.Format("Access Code:{0}",item.AccessCode),"Spot2Share:Login Code");

        }
        else {
res.success = false;
res.message ="Authentication Failed.";
        }
        return new ObjectResult(res);

    }

private Random random = new Random();
private string RandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, length)
      .Select(s => s[random.Next(s.Length)]).ToArray());
}

  }
}
