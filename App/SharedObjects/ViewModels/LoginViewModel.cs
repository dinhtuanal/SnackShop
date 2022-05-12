using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Không được để trống email đăng nhập")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Không được để trống mật khẩu")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
