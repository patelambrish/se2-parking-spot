using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;
using DataAccess.Models;

namespace QuickstartIdentityServer.Framework
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private spot2shareContext _dbContext;
        public ResourceOwnerPasswordValidator(spot2shareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            string username = context.UserName;
            string password = context.Password;
            bool isAuth = false;
            AuthToken record = _dbContext.AuthToken.Where(
              t => t.EmailAddress.Equals(username, StringComparison.CurrentCultureIgnoreCase) && t.AccessCode.Equals(password, StringComparison.CurrentCultureIgnoreCase) && !t.IsUsed).FirstOrDefault();

            if(record != null) {
              isAuth=true;
            }

            if(!isAuth)
            {
                context.Result = new GrantValidationResult(TokenErrors.InvalidRequest, "Invalid Credentials", null);
                context.Result.IsError = true;
                return Task.FromResult(context.Result);
            }

            record.UpdateDate=DateTime.Now;
            record.IsUsed = true;
            _dbContext.SaveChanges();
            context.Result = new GrantValidationResult(context.UserName, "password");
            return Task.FromResult(context.Result);

        }
    }
}
