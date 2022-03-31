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
        public IActionResult GetData(string users)

        {

            //Users users = new Users();

            //MemoryStream stream = new MemoryStream();

            //Request.Body.CopyTo(stream);

            //stream.Position = 0;

            //using (StreamReader reader = new StreamReader(stream))

            //{

            //    string requestBody = reader.ReadToEnd();

            //    if (requestBody.Length > 0)

            //    {

            //        users = JsonConvert.DeserializeObject<Users>(requestBody);

            //    }

            //}



            return Json(users);

        }
        public class Users

        {

            public string Name { get; set; }

            public string Address { get; set; }

            public string PhoneNo { get; set; }

        }

    }
}
