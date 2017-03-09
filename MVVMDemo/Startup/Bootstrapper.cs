using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MVVMDemo.Providers;
using MVVMDemo.ViewModels;
using MVVMDemo.Views;
using Prism.Events;

namespace MVVMDemo.Startup
{
    public class Bootstrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>()
                .As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<WeatherProvider>().As<IWeatherProvider>();
            builder.RegisterType<WeatherViewModel>().AsSelf();
            builder.RegisterType<WeatherView>().AsSelf();


            return builder.Build();

        }
    }
}
