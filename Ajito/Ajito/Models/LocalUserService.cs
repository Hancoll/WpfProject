using Ajito.Models.Interfaces;
using Ajito.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajito.Models
{
    internal class LocalUserService : IUserService
    {
        private UsersController controller;

        public bool Authenticate(User user)
        {
            return controller.Authenticate(user);
        }

        public bool Registrate(User user)
        {
            return controller.Registrate(user);
        }

        public LocalUserService(UsersController controller)
        {
            this.controller = controller;
        }
    }
}
