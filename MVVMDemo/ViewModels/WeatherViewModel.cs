using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMDemo.Models;
using MVVMDemo.Providers;
using Prism.Commands;

namespace MVVMDemo.ViewModels
{
    public class WeatherViewModel : ViewModelBase
    {
        public ICommand SubmitSearch { get; private set; }
        public WeatherViewModel(IWeatherProvider provider)
        {
            _provider = provider;
           SubmitSearch = new DelegateCommand(OnSearchExecute, OnSearchCanExecute);
            ZipCode = string.Empty;
        }

        private bool OnSearchCanExecute()
        {
            return _zipcode.Length == 5;
        }

        private async void OnSearchExecute()
        {
           await Task.Run(() =>
           {
               try
               {
                   var result = _provider.GetTemperatureByZip(_zipcode);
                   Result = result;
               }
               catch (Exception e)
               {
                   Console.WriteLine(e);
                   throw;
               }
               
           });
        }

        private WeatherResult _result;

        public WeatherResult Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)SubmitSearch).RaiseCanExecuteChanged();
 
        }


        private string _zipcode;
        private IWeatherProvider _provider;

        public string ZipCode
        {
            get { return _zipcode; }
            set
            {
                _zipcode = value;
                OnPropertyChanged();
                InvalidateCommands();
            }
        }

    }
}
