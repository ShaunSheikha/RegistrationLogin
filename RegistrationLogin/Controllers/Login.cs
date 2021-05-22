using Microsoft.AspNetCore.Mvc;
using RegistrationLogin.Data.Interfaces;
using RegistrationLogin.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RegistrationLogin.Core;
using System.Net.Http.Json;

namespace RegistrationLogin.Controllers
{
    public class Login : Controller
    {

        private IHttpClientFactory _httpClientFactory;

        public Login(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogMeIn(string email, string password)
        {

            var client = _httpClientFactory.CreateClient();
            User loggedInUser = null;

            using (client)
            {
                client.BaseAddress = new Uri(Helper.GetApiAddress());
                try
                {
                    //i'm 90% sure there's a better way to pass a password
                    var x = client.GetFromJsonAsync<User>($"/Login?email={email}&password={password}");
                    x.Wait();
                    if (x.Result.Id > -1)
                    {
                        loggedInUser = x.Result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (loggedInUser == null)
            {
                return Redirect(Url.Content("~/Login"));
            }
            else
            {
                ViewData["firstName"] = loggedInUser.FirstName;
                return View("LoggedIn");
            }

        }

        



    }
}
