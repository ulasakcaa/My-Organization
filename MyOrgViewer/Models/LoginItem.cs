using MyOrgViewer.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyOrgViewer.Models
{
    public class LoginItem
    {
        [Required]
        [NameVal]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}