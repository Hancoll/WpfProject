using Ajito.Models;
using Ajito.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ajito.Server.Controllers
{
    public class UsersController
    {
        private AppDbContext context;

        public bool Authenticate(User user) =>
            context.Users.Select(x => x.Login == user.Login && x.Password == user.Password).Count() != 0;

        public bool Registrate(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            catch
            {
                return false;
            }

            return true;
        }

        internal UsersController(AppDbContext context)
        {
            this.context = context;
        }
    }
}
