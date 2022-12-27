using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AdminInfo
    {
        public int Id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
