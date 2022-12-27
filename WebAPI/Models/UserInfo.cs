using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Models
{
    public class UserInfo
    {
       
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        public string LName { get; set; }
        [Required]
        [Remote(action: "VerifyEmail", controller: "UserInfo")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long Phone { get; set; }
        
    }
}
