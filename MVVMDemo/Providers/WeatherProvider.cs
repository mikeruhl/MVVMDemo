using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Models;
using Newtonsoft.Json.Linq;

namespace MVVMDemo.Providers
{
    /// <summary>
    /// Provides weather data from OpenWeatherMap.org
    /// </summary>
    public class WeatherProvider : IWeatherProvider
    {
        // Get your own API at www.openweathermap.org
        private const string Apikey = "";
        private const string Baseurl = @"http://api.openweathermap.org/data/2.5/weather";


        public WeatherResult GetTemperatureByZip(string zip)
        {
            var resp = new WeatherResult();
            var request = (HttpWebRequest) WebRequest.Create(Baseurl + "?zip=" + zip + ",us&APPID=" + Apikey);
            DoWithResponse(request, (response) =>
            {
                if (response == null) return;
                using (var stream = response.GetResponseStream())
                {
                    var body = new StreamReader(stream).ReadToEnd();
                    var parsed = JObject.Parse(WebUtility.HtmlDecode(body));

                    var main = parsed["main"];
                    resp.Name = parsed["name"].Value<string>();
                    resp.Temp = (int)((double)main["temp"].Value<int>() * 9 / 5 - 459.67);
                }
                
            });
            return resp;
            
        }

        private static void DoWithResponse(WebRequest request, Action<HttpWebResponse> responseAction)
        {
            Action wrapperAction = () =>
            {
                request.BeginGetResponse((iar) =>
                {
                    var response = (HttpWebResponse)((HttpWebRequest)iar.AsyncState).EndGetResponse(iar);
                    responseAction(response);
                }, request);
            };
            wrapperAction.BeginInvoke((iar) =>
            {
                var action = (Action)iar.AsyncState;
                action.EndInvoke(iar);
            }, wrapperAction);
        }
    }
}
