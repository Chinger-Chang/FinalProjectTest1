using FinalProjectFirstTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
       // 連線SQL
        private IConfiguration _config;
        private Models.DBUtility _dBUtility; //引入DB 模組 做連線
        private Models.FinalProjectDbContext _dbContext;

        public UserController(IConfiguration config, Models.DBUtility _dBUtility, Models.FinalProjectDbContext _dbContext)
        {
            Console.WriteLine("UserController控制台活過來!!!~");
            _config = config;
            this._dBUtility = _dBUtility;//注入進來的Connetion Factory 物件 --0217
            this._dbContext = _dbContext;
        }

        private readonly List<User> _db;  //建構子

        //註冊 Registration Action

        //註冊推送 Registration Post action


        // 郵件認證 Verify Email

        // 郵件認證連接 Verify Email LINK

        //會員中心 Center
        public IActionResult UserCenter()
        {
            return View();
        }

        //會員登入 Login 畫面
        public IActionResult UserLogin()
        {  //View 有登入畫面
            return View();
        }


        //會員登出 Logout




        
        //測試
       //以post 接收
        //會員登入 Login action
        //接受前端表單Post回來的Email &Password
         [HttpPost]  
        public IActionResult GetData([FromForm] UsersModel usersModel)
        {    // 查詢傳來帳號與密碼是否有 [FromBody]UsersModel model [FromForm] 

            // TODO
            Console.WriteLine($"登入帳號密碼");

             return View();
        //    return Json(model);
        }


        public class UsersModel

        {
            public string Email { get; set; }

            public string Password { get; set; }
  
        }

     }
}
