﻿using FinalProjectFirstTest.Models;
using FinalProjectFirstTest.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProjectFirstTest.Services;

namespace FinalProjectFirstTest.Controllers
{
    /**Buyer Controller */
    public class UserController : Controller
    {
       // 連線SQL

        private Models.DBUtility _dBUtility; //引入DB 模組 做連線
        private Models.FinalProjectDbContext _db;

        public UserController(
            Models.DBUtility _dBUtility,
            Models.FinalProjectDbContext _db)
        {
            Console.WriteLine("UserController控制台活過來!!!~");
           this._dBUtility = _dBUtility;//注入進來的Connetion Factory 物件 
            this._db = _db;
        }
        public IActionResult UserReg()
        {
            return View();
        }


        //註冊 Registration Action
        public IActionResult Registration()
        {
            return View();
         }

        //註冊推送 Registration Post action
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult RegistrationPost(ModelReg user)
        {
            if(ModelState.IsValid)
            {
                var userreg=_db.Users.FirstOrDefault(x=>x.Email== user.Email);  //資料表名稱User名稱內 搜尋到是否有這樣咚咚
                //創建一個新的User表
                if (userreg == null)
                {
                    _db.Users.Add(new User()
                    {
                        Email = user.Email,
                        Password = user.Password,
                        Name = user.Name,
                        Phone = user.Phone,
                        CreateDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsMailConfirm = false
                    }); //前端所進來之資料 加入至伺服端 資料表做準備儲存
                    _db.SaveChanges(); //進行儲存 變更動作
                    return RedirectToAction("Index", "Home");  //導入至首頁
                }
                else {
                    //以被使用
                    return Content("已被使用");

                }
                
            }else
            {
                return RedirectToPage("Index");  //導入至首頁
            }

            // return View();  
        }

        //---------------------------------------
        //寄信
        public ActionResult SendMail()
        {   
            var mails = new string[] {"t108458055@gmail.com"};
            var mailhelper = new MailHelper();
            mailhelper.CreateMail(mails,"測試","<h1>Hello</h1>");
            mailhelper.Send();

            return Content("寄信");
        }


        //-------------------------------
        // 郵件認證 Verify Email
        public IActionResult VerifyEmail()
        {
            return View();
        }
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
        public IActionResult UserLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }




        //測試
        //以post 接收
        //會員登入 Login action
        //接受前端表單Post回來的Email &Password
        [HttpPost]  
        public async Task<IActionResult> GetDataAsync(UsersModel user)
        {    // 查詢傳來帳號與密碼是否有 [FromBody]UsersModel model [FromForm] [FromForm]
             // TODO
            Console.WriteLine($"登入帳號:{user.Email}密碼:{user.Password}");
            if (ModelState.IsValid)
            {
                var userlogin = _db.Users.FirstOrDefault(k => k.Email == user.Email && k.Password == user.Password);
                if (userlogin == null)
                {
                    return Content("帳號密碼錯誤");
                }
                else
                {
                    //這邊寫入Cookie驗證 並創建一個物件 Claim list
                    var claims = new List<Claim>
                    { 
                        new Claim(ClaimTypes.Name, userlogin.Email),
                        new Claim("Name",userlogin.Name)
                        //new Claim(ClaimTypes.Role,"Administrato0r")
                    };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal=new ClaimsPrincipal(claimIdentity);
                   await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                    return RedirectToAction("Index", "Home");
                }
            }
            return Content("Err");
        //    return Json(model);
        }

        //其他登入方式
        public IActionResult FBLogin()
        {
            var properites = new AuthenticationProperties() {
                RedirectUri=Url.Action("FacebookResponse")
            };
            return Challenge(properites,FacebookDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var data=result.Principal.Claims.Select(x=> new 
            {
                    x.Type,
                    x.Value,
                    x.Issuer,
                    x.OriginalIssuer
            } );
            return Json(data);
        }


        [Route("google-login")]
        public IActionResult GGLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties,GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                { 
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            return Json(claims);
        }


        // Tests string
        public class UsersModel

        {
            public string Email { get; set; }

            public string Password { get; set; }
  
        }

     }
}
