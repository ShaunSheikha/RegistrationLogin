using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationLogin.Core;
using RegistrationLogin.Data.Interfaces;
using RegistrationLogin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Register : ControllerBase
    {
        private readonly IRegister _register;

        public Register(IRegister register)
        {
            _register = register;
        }

        //change return type
        [HttpPost]
        public User RegisterNewUser(User user)
        {
            return _register.RegisterNewUser(user);
        }
    }
}
