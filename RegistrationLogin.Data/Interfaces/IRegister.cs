using RegistrationLogin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationLogin.Data.Interfaces
{
    public interface IRegister
    {
        public User RegisterNewUser(User user);
    }
}
