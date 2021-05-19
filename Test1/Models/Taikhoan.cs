﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Taikhoan
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bạn chưa nhập Tài khoản!")]
        [Display(Name ="Tài khoản")]
        public string UserNameUS { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Mật khẩu!")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Mật khẩu!")]
        [Display(Name = "Mật khẩu lại")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password",ErrorMessage ="Nhập lại mật khẩu không đúng, mời nhập lại!")]
        public string RePassword { get; set; }
    }
}