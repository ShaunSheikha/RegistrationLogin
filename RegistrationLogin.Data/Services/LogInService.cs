using Microsoft.EntityFrameworkCore;
using RegistrationLogin.Core;
using RegistrationLogin.Data.Interfaces;
using RegistrationLogin.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationLogin.Data.Services
{
    public class LogInService : ILogIn
    {

        public User VerifyAccount(string email, string password) {

            User user = null;
            string hashedPassword = Helper.ComputeSha256Hash(password);

            using (var context = new RegistrationLoginMVCContext())
            {
                try
                {
                    user = context.Users.Where(u => u.Email == email).Where(u => u.Password == hashedPassword).ToList()[0];
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return user;

            }

        
    }
}
