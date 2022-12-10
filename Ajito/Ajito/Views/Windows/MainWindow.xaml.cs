using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ajito.Models;
using Ajito.ViewModels;
using Ajito.Views.Pages;
using Ajito.Views.Windows;
using Autofac;

namespace Ajito
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserData userData;
        private HomePage homePage;

        public MainWindow(UserData userData)
        {
            userData.UserDataChanged += (o, e) => UpdateUserInformation();
            this.userData = userData;
            homePage = new HomePage() { DataContext = App.Container.Resolve<HomeViewModel>() };
            InitializeComponent();
            UpdateUserInformation();
            PageContainer.Navigate(homePage);
        }

        private void UpdateUserInformation()
        {
            bool isLoggedIn = userData.User != null;

            authLink.Visibility = isLoggedIn ? Visibility.Hidden : Visibility.Visible;
            userProfileLink.Visibility = isLoggedIn ? Visibility.Visible : Visibility.Hidden;

            if (isLoggedIn)
                userProfileLink.Text = userData.User.Login;
        }

        private void OnAuthorizationClick(object sender, MouseButtonEventArgs e)
        {
            foreach(Window window in OwnedWindows)
            {
                if (window is AuthorizationWindow)
                    return;
            }

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Owner = this;
            authorizationWindow.Show();
        }
    }
}
