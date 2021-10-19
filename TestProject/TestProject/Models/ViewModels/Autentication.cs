using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models.ViewModels
{
    public class Autentication
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string pass { get; set; }
    }
}