using Ajito.Server.Controllers;
using Ajito.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ajito.Server
{
    public class Startup
    {
        public AdsController AdsControler { get; private set; }
        public UsersController UsersControler { get; private set; }

        private AppDbContext dbContext;
        
        public Startup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlite("Data Source=AppDb.db;").Options;
            dbContext = new AppDbContext(options);

            AdsControler = new AdsController(dbContext);
            UsersControler = new UsersController(dbContext);
        }
    }
}
