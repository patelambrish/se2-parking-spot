using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using WebAPI.Models;
using WebAPI.Services;
//using System.Net.Http;

namespace WebAPI.Controllers
{

  public class AccountController : Controller
  {

    private IRegistrationService _regService;
    public AccountController(IRegistrationService regService)
    {
      _regService = regService;
    }

    // POST api/values
    [HttpPost]
    [Route("api/[controller]")]
    public IActionResult Post([FromBody]Account account)
    {
      if (ModelState.IsValid)
      {
        ReturnResponse response = _regService.RegisterAccount(account,
            this.Url.Action("Activate", null, null, Request.Scheme));
        return new ObjectResult(response);
      }
      else
      {
        return new ObjectResult(ModelState);
      }
    }

    [HttpGet("{id}")]
    [Route("api/[controller]/[Action]")]
    public IActionResult Activate(string id)
    {
      if (_regService.ActivateAccount(id))
      {
        return Redirect("http://localhost:4200?messsage=Account is activated successfully.&success=true");
      }
      else
      {
        return Redirect("http://localhost:4200?messsage=An unexpected error occured while activating account&success=false");
      }
    }
  }
}
