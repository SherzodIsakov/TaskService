using AuthenticationService.Client;
using AuthenticationService.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Services.AuthServices
{
    public class TokenService
    {
        private readonly IAuthenticationClient _authenticationClient;
        public TokenService(IAuthenticationClient authenticationClient)
        {
            _authenticationClient = authenticationClient;
        }

        public async Task<string> GetToken(LoginModel loginModel)
        {
            string token = string.Empty;
            ObjectResult objectResult = await _authenticationClient.Login(loginModel);

            if (objectResult != null)
            {
                LoginResponse loginResponse = objectResult.Value as LoginResponse;
                token = loginResponse.Token;
            }

            return string.IsNullOrWhiteSpace(token)? "Error token": token;
        }
    }
}
