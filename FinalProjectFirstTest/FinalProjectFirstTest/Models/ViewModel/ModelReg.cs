using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models.ViewModel
{  //給 使用者註冊所使用ViewModel
    public class ModelReg
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsMailConfirm { get; set; }
    }
}
