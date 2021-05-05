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

        public IActionResult LogMeIn(string email, string password)
        {

            string connString = "Server=(local);Database=RegistrationLoginMVC;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(
               connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"select * from [dbo].[User] where email = @email and password = Hashbytes('SHA2_256', '{password}');", connection);
                sqlCommand.Parameters.AddWithValue("@email", email);
                //sqlCommand.Parameters.AddWithValue("@password", password);


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
                    ViewData["firstName"] = dataTable.Rows[0]["firstName"].ToString();
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
