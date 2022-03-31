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
    //Buyer Controller
    public class UserController : Controller
    {
        private readonly List<User> _db;

        //註冊 Registration Action

        //註冊推送 Registration Post action


        // 郵件認證 Verify Email

        // 郵件認證連接 Verify Email LINK

        //會員中心 Center
        public IActionResult UserCenter()
        {
            return View();
        }

        //會員登入 Login
        public IActionResult UserLogin()
        {
            return View();
        }

        //會員登出 Logout





        //測試
        [HttpPost]
        public IActionResult Usercheckin(string account,string password)

        {
            Console.WriteLine($"登入帳號{account}密碼{password}");
            
            return Content($@"帳號{account}/密碼{password}");
        }


        public class UsersModel

        {
            public string account { get; set; }

            public string password { get; set; }

   
          
        }

     }
}
