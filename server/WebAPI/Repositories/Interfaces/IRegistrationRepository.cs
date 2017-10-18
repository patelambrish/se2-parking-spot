using WebAPI.Models;

namespace WebAPI.Repositories
{
  public interface IRegistrationRepository
  {

    Account GetAccount(string searchBy, string searchValue);
    string CreateAccount(Account account);
    bool UpdateAccount(Account account);
    bool ActivateAccount(string activationKey);
  }
}