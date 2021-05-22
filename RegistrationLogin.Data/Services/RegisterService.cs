using Microsoft.EntityFrameworkCore;
using RegistrationLogin.Core;
using RegistrationLogin.Data.Interfaces;
using RegistrationLogin.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationLogin.Data.Services
{
    public class RegisterService : IRegister 
    {
        public User RegisterNewUser(User user) {

            using (var context = new RegistrationLoginMVCContext())
            {
                user.Password = Helper.ComputeSha256Hash(user.Password);
                context.Add(user);
                context.SaveChanges();

            }
            return user;


        }
        
    }
}
