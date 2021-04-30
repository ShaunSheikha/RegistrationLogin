using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogMeIn(string email, string firstName)
        {

            string connString = "Server=(local);Database=RegistrationLoginMVC;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(
               connString))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[User] where email = @email and firstName =@firstName;",connection);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@firstName", firstName);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                try
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                catch(Exception e)
                {

                }

                if(dataTable.Rows.Count > 0)
                {
                    ViewData["firstName"] = firstName;
                    return View();
                }
                else
                {
                    return Redirect(Url.Content("~/Login"));
                }
            }

        }

        



    }
}
