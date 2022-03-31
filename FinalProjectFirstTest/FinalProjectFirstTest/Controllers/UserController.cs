using FinalProjectFirstTest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Controllers
{
    public class UserController : Controller
    {
        private readonly List<User> _db;
        public IActionResult UserCenter()
        {
            return View();
        }


        public IActionResult UserLogin()
        {
            return View();
        }
        //測試
        [HttpPost]
        public Boolean Usercheckin(UsersModel ssr)

        {
            Console.WriteLine(ssr.Name);
            return true;
        }


        public class UsersModel

        {
            public string Name { get; set; }

            public string Address { get; set; }

            public string PhoneNo { get; set; }
          
        }

     }
}
