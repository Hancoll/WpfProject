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

namespace Ajito.Views.Pages.Authorization
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public event Action OnSignInClicked;

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void OnSignInClick(object sender, RoutedEventArgs e)
        {
            OnSignInClicked?.Invoke();
        }
    }
}
