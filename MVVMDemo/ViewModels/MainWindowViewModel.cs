using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Providers;

namespace MVVMDemo.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IWeatherProvider provider)
        {
            _weather = new WeatherViewModel(provider);
        }

        private WeatherViewModel _weather;

        public WeatherViewModel Weather
        {
            get { return _weather; }
            set
            {
                _weather = value; 
                OnPropertyChanged();
            }
        }


    }
}
