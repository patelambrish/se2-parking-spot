using WebAPI.Models;
using DataAccess.Models;
using System.Linq;
using System;

namespace WebAPI.Repositories
{

  public class RegistrationRepository : IRegistrationRepository
  {
    private spot2shareContext _context;
    public RegistrationRepository(spot2shareContext context)
    {
      _context = context;
    }

    public Account GetAccount(string searchBy, string searchValue)
    {
      Registration reg = null;
      switch (searchBy.ToLower())
      {
        case "id":
          reg = _context.Registration.Where(r => r.Id == Int32.Parse(searchValue)).FirstOrDefault();
          break;
        case "email":
          reg = _context.Registration.Where(r => r.EmailAddress.Equals(searchValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
          break;
        case "activationkey":
          reg = _context.Registration.Where(r => r.ActivationKey == searchValue).FirstOrDefault();
          break;
        case "mobilenumber":
          reg = _context.Registration.Where(r => r.MobileNumber.Equals(searchValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
          break;
      }
      if (reg == null)
      {
        return null;
      }
      else
      {
        return Map(reg);
      }
    }

    public string CreateAccount(Account account)
    {

      account.IsActive = false;
      Registration reg = ReverseMap(account);
      reg.ActivationKey = Guid.NewGuid().ToString();
      reg.UpdateDate = DateTime.Now;
      _context.Registration.Add(reg);
      int count = _context.SaveChanges();
      if (count > 0)
      {
        return reg.ActivationKey;
      }
      else
      {
        throw new Exception("No records were inserted.");
      }

    }
    public bool UpdateAccount(Account account)
    {
      throw new NotImplementedException();
    }

    public bool ActivateAccount(string activationKey)
    {
      Registration reg = _context.Registration.Where(r => r.ActivationKey == activationKey).FirstOrDefault();
      if(reg==null)
      {
        return false;
      }
      else
      {
        reg.IsActive = true;
        reg.UpdateDate = DateTime.Now;
        int count = _context.SaveChanges();
        if (count > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    private Account Map(Registration reg)
    {
      if (reg == null)
      {
        return null;
      }
      else
      {
        return new Account
        {
          Id = reg.Id,
          EmailAddress = reg.EmailAddress,
          MobileNumber = reg.MobileNumber,
          Name = reg.Name,
          IsActive = reg.IsActive
        };
      }
    }

    private Registration ReverseMap(Account account)
    {
      if (account == null)
      {
        return null;
      }
      else
      {
        return new Registration
        {
          Id = account.Id,
          EmailAddress = account.EmailAddress,
          MobileNumber = account.MobileNumber,
          Name = account.Name,
          IsActive = account.IsActive
        };
      }
    }

  }

}
