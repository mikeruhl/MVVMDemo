using System;
using System.Diagnostics.Eventing.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVVMDemo.Models;
using MVVMDemo.Providers;
using MVVMDemo.ViewModels;

namespace MVVMDemo.Tests
{
    [TestClass]
    public class WeatherViewModelTests
    {
        private Mock<IWeatherProvider> _providerMock;
        private readonly WeatherViewModel _viewModel;
        public WeatherViewModelTests()
        {
            _providerMock = new Mock<IWeatherProvider>();
            
            _viewModel = new WeatherViewModel(_providerMock.Object);
        }

        [TestMethod]
        public void CantSubmitWithoutZip()
        {
            Assert.AreEqual(_viewModel.SubmitSearch.CanExecute(null), false);
        }
        [TestMethod]
        public void CanSubmitWithoutZip()
        {
            _viewModel.ZipCode = "12345";
            Assert.AreEqual(_viewModel.SubmitSearch.CanExecute(null), true);
        }
        [TestMethod]
        public void CantSubmitWithPartialZip()
        {
            _viewModel.ZipCode = "123";
            Assert.AreEqual(_viewModel.SubmitSearch.CanExecute(null), false);
        }

        [TestMethod]
        public void ShouldReturnCanLive()
        {
            _viewModel.Result = new WeatherResult
            {
                Name = "Test",
                Temp = 1
            };
            Assert.IsTrue(_viewModel.Result.WouldIGo.Contains("I would not go"));
          
        }

        [TestMethod]
        public void ShouldReturnCantLive()
        {
            _viewModel.Result = new WeatherResult
            {
                Name = "Test",
                Temp = 80
            };
            Assert.IsTrue(_viewModel.Result.WouldIGo.Contains("I would go"));
        }

    }
}
