using Ajito.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ajito.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Ajito.ViewModels
{
    public class AuthorizationViewModel
    {
        public event Action OnAuthorizationComplete;
        public event Action OnRegistrationComplete;
        private IUserService userService;
        private UserData userData;

        public string Login { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string ConfirmedPassword { get; set; } = String.Empty;

        private RelayCommand signIn;
        public RelayCommand SignIn
        {
            get
            {
                return signIn ??
                    (signIn = new RelayCommand((obj) =>
                    {
                        if (!IsValid(Login, Password))
                            return;

                        User user = new User() { Login = Login, Password = Password };

                        if (!userService.Authenticate(user))
                            return;

                        userData.User = user;
                        OnAuthorizationComplete?.Invoke();
                    }));
            }
        }

        private RelayCommand signUp;
        public RelayCommand SignUp
        {
            get
            {
                return signUp ??
                    (signUp = new RelayCommand((obj) =>
                    {
                        if (!IsValid(Login, Password, ConfirmedPassword))
                            return;

                        User user = new User() { Login = Login, Password = Password };

                        if (!userService.Registrate(user))
                            return;

                        OnRegistrationComplete?.Invoke();
                    }));
            }
        }

        private bool IsValid(string login, string password, string confirmedPassword = null)
        {
            if(login.Length < 4)
                return false;
            if (password.Length < 4)
                return false;
            if (confirmedPassword != null && password != confirmedPassword)
                return false;

            return true;
        }

        public AuthorizationViewModel(IUserService userService, UserData userData)
        {
            this.userService = userService;
            this.userData = userData;
        }
    }
}
