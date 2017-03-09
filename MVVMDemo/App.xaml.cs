using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using MVVMDemo.Startup;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {


            var bootStrapper = new Bootstrapper();
            var container = bootStrapper.BootStrap();

            var fileWindow = container.Resolve<MainWindow>();
            fileWindow.Show();
        }
    }
}
