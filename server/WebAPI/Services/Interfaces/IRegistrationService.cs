using System;
using WebAPI.Models;

namespace WebAPI.Services {
    public interface IRegistrationService {
        ReturnResponse RegisterAccount(Account account, string url);
        bool ActivateAccount(string activationId);
        
    }
}