using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeweleryApp.Models
{
    public class JeweleryDbContext : DbContext
    {
        public JeweleryDbContext(DbContextOptions<JeweleryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GoldItem> GoldItems { get; set; }
    }
}
