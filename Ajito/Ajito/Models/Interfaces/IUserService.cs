using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajito.Models;

namespace Ajito.Models.Interfaces
{
    public interface IUserService
    {
        bool Authenticate(User user);

        bool Registrate(User user);
    }
}
