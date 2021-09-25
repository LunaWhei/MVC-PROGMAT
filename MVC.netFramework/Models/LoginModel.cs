using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.netFramework.Models
{
    public class LoginModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage="This field is required.")]
        public string Login { get; set; }
        [DisplayName("User Password")]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}