using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationLogin.Models;
using System.Data.SqlClient;



namespace RegistrationLogin.Controllers
{
    public class Register : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterNewUser(User user)
        {
            string sqlQuery = $"insert into [dbo].[User](firstName, lastName, email, age) values ('{user.firstName}','{user.lastName}','{user.email}',{user.age});";
            string connString = "Server=(local);Database=RegistrationLoginMVC;Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(
               connString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            /*SqlConnection connection = new SqlConnection(connString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            foreach(DataRow row in dataTable.Rows)
            {
                testString = row["firstName"].ToString();
            }
*/
            return Redirect(Url.Content("~/"));
        }
    }
}
