using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajito.Models
{
    public class UserData
    {
        public event EventHandler<EventArgs> UserDataChanged;

        private User user;
        public User User
        {
            get => user;

            set
            {
                user = value;
                UserDataChanged?.Invoke(this, new EventArgs());
            }
        }

    }
}
