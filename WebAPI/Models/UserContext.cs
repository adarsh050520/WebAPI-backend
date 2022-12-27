using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Configuration;

namespace WebAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<AdminInfo> AdminInfo { get; set; }




    }
}