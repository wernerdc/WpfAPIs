using RestSharp;
using System;
using System.Collections.Generic;
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
            var client = new RestClient("https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?lat=35.5&lon=-78.5&units=imperial&lang=en");
            var request = new RestRequest();
            request.AddHeader("x-rapidapi-key", "9b8f8f04e6mshcaa3f16bf2623dcp162c0ajsne22516b5fcd4");
            request.AddHeader("x-rapidapi-host", "weatherbit-v1-mashape.p.rapidapi.com");
            //IRestResponse response = client.Execute(request);
            var response = await client.GetAsync<WeatherModel>(request, CancellationToken.None);
            if (response == null)
                return;
            dGridWeather.ItemsSource = null;
            dGridWeather.ItemsSource = response.data;
        }
    }
}
