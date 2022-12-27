using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly UserContext _context;

        public AdminLoginController(UserContext context)
        {
            _context = context;
        }

        [Route("AdminLogin")]
        [HttpPost]
        public ActionResult MyAdmin(AdminInfo login)
        {
            var log = _context.AdminInfo.Where(x => x.email.Equals(login.email) && x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid Admin", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "Admin Logged successfully", UserDetails = log });
        }
    }
}
