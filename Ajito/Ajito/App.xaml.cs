using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ajito.Models;
using Ajito.Models.Interfaces;
using Ajito.ViewModels;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace Ajito
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            var server = new Server.Startup();
            builder.RegisterInstance(new LocalAdsService(server.AdsControler)).As<IAdsService>();
            builder.RegisterInstance(new LocalUserService(server.UsersControler)).As<IUserService>();
            builder.RegisterInstance(new UserData());
            Container = builder.Build();

            MainWindow = Container.Resolve<MainWindow>();
            MainWindow.Show();
        }
    }
}
