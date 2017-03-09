# MVVMDemo
Provides a small demo showcasing the MVVM pattern with testing using dependency injection and inversion of control

## Overview

The app is very simple: You can input a zip code in the provided text box, and it will fetch the current temperature from [openweathermap.org](http://www.openweathermap.org).  If the temperature is over 60F, it will display that I would travel there.  If it's under that temperature, it will show that I won't.

This program demonstrates good coding practices for separating the View and the ViewModel in WPF.  It also shows how to moq an interface and provide test data for unit testing purposes.  I think it shows some good fundamental techniques for writing WPF in the MVVM framework.

There are two projects in the sln, the main demo and the test project.  The main demo uses Prism and Autofac to achieve MVVM.  The UI is written in WPF.  The tests use Moq for mocking.

## Notes

To get this to run properly, you have to obtain an API key from [OpenWeatherMap.org](http://openweathermap.org/appid) and place in in Providers\WeatherProvider.cs in the Apikey variable:

```CSharp
private const string Apikey = "";
```