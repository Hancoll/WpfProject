using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajito.Models;

namespace Ajito.Server.Data
{
    internal class AppDbContext: DbContext
    {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
