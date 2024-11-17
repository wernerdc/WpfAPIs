using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfAPIs.Models;

namespace WpfAPIs
{
    /// <summary>
    /// Interaktionslogik für Weather.xaml
    /// </summary>
    public partial class WeatherControl : UserControl
    {
        public WeatherControl()
        {
            InitializeComponent();
        }

        private async void btnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            await GetWeather();
        }

        private async Task GetWeather()
        {
            var client = new RestClient("https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?lat=48.8&lon=8.2&units=metric&lang=de");
            var request = new RestRequest();
            request.AddHeader("x-rapidapi-key", "ec8cca8d91msha4035d03d0a62fep1a974ejsn81cd8f210bd0");
            request.AddHeader("x-rapidapi-host", "weatherbit-v1-mashape.p.rapidapi.com");

            //var response = client.Execute(request);
            //Debug.WriteLine(response.ToString());
            var response = await client.GetAsync<WeatherModel>(request, CancellationToken.None);
            if (response == null)
                return;
            dGridWeather.ItemsSource = null;
            dGridWeather.ItemsSource = response.data;
        }
    }
}
