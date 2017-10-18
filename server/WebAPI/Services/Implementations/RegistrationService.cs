using System;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
  public class RegistationService : IRegistrationService
  {

    private IRegistrationRepository _regRepo;
    private IEmailRepository _emailRepo;
    public RegistationService(IRegistrationRepository regRepo, IEmailRepository emailRepo)
    {
      _regRepo = regRepo;
      _emailRepo = emailRepo;
    }
    public ReturnResponse RegisterAccount(Account account, string url)
    {

      ReturnResponse res = new ReturnResponse();
      Account acct = _regRepo.GetAccount("email", account.EmailAddress);
      if (account.Id == 0 && acct == null)
      {
        string activationKey = _regRepo.CreateAccount(account);

        _emailRepo.SendEmail(
            account.EmailAddress,
            "noreply@se2.com",
            String.Format("<a href=\"{0}?id={1}\">Click Here to activate your account</a>", url, activationKey),
            "SE2 Spot2Share Account Activation"
        );
        res.success = true;
        res.message = String.Format("Account Registered successfully.");
        //res.reference = activationKey;
      }
      else
      {
        res.success = false;
        res.message = String.Format("Account already exists.");
      }

      return res;
    }

    public bool ActivateAccount(string activationId)
    {
      return _regRepo.ActivateAccount(activationId);       
    }

  }
}
