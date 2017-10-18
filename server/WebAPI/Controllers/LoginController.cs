using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using WebAPI.Models;
using WebAPI.Repositories;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    public class LoginController: Controller
    {
        public LoginController()
        {

        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<object> Post([FromBody]Login login)
        {

            // discover endpoints from metadata
            //var disco = DiscoveryClient.("http://localhost:5001");

            // request token
            var disco = await DiscoveryClient.GetAsync("http://localhost:5001");

            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(login.EmailAddress, login.AccessCode, "openid");

            if (tokenResponse.IsError)
            {
                return (tokenResponse.Error);
            }

            return tokenResponse.Json;

        }
    }
}
