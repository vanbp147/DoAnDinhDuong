using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Doandinhduong.Models
{
    public class RegisterModel
    {

        [Key]
        public int ID_Nguoidung { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]

        public string Taikhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Matkhau { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Matkhau", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string Matkhauxacnhan { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]        
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }

        
        
    }
}
