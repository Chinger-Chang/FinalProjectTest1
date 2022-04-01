using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult SellerCenter()
        {
            return View();
        }
    }
}
