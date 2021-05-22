using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationLogin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationLogin.Data.Services;
using RegistrationLogin.Data.Interfaces;

namespace RegistrationLogin.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {

        private readonly ILogIn _logIn;
        public Login(ILogIn logIn) {
            _logIn = logIn;
        }

        [HttpGet]
        public User GetUser(string email, string password)
        {
            return _logIn.VerifyAccount(email, password);
        }
    }
}
