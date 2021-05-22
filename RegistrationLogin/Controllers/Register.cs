using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationLogin.Data.Models;
using System.Data.SqlClient;
using RegistrationLogin.Data.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace RegistrationLogin.Controllers
{
    public class Register : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Register(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterNewUser(User user)
        {
            var client = _httpClientFactory.CreateClient();
            using (client)
            {
                client.BaseAddress = new Uri("https://localhost:44372/Register");
                var response = client.PostAsJsonAsync<User>("register", user);
                response.Wait();

                var res = response.Result;
                if(res.IsSuccessStatusCode)
                {
                    return Redirect(Url.Content("/"));
                }
            }

            return Redirect(Url.Content("~/"));
        }
    }
}
