using Ajito.ViewModels;
using Ajito.Views.Pages.Authorization;
using Autofac;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ajito.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private const int SignInWindowSize = 450;
        private const int SignUpWindowSize = 530;
        private AuthorizationViewModel viewModel;

        public AuthorizationWindow()
        {
            viewModel = App.Container.Resolve<AuthorizationViewModel>();
            viewModel.OnAuthorizationComplete += OnAuthorizationComplete;
            viewModel.OnRegistrationComplete += OnRegistrationComplete;
            InitializeComponent();
            OpenPage<SignInPage>();
        }

        private void OnAuthorizationComplete()
        {
            Close();
        }

        private void OnRegistrationComplete()
        {
            OpenPage<SignInPage>();
        }

        private void OpenPage<T>() where T : Page, new()
        {
            var page = new T();
            page.DataContext = viewModel;

            viewModel.Login = String.Empty;
            viewModel.Password = String.Empty;
            viewModel.ConfirmedPassword = String.Empty;

            if (typeof(T) == typeof(SignInPage))
            {
                (page as SignInPage).OnSignUpClicked += () => OpenPage<SignUpPage>();
                Height = SignInWindowSize;
            }

            else
            {
                (page as SignUpPage).OnSignInClicked += () => OpenPage<SignInPage>();
                Height = SignUpWindowSize;
            }

            Container.Navigate(page);
        }
    }
}
