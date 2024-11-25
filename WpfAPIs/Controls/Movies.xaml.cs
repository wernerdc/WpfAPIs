﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    /// Interaktionslogik für Movies.xaml
    /// </summary>
    public partial class MoviesControl : UserControl
    {
        public MoviesControl()
        {
            InitializeComponent();
        }

        private async void btnGetMovies_Click(object sender, RoutedEventArgs e)
        {
            await GetMovies();
        }

        private async Task GetMovies()
        {
            var client = new RestClient("https://imdb-top-100-movies.p.rapidapi.com/");
            var request = new RestRequest();
            request.AddHeader("x-rapidapi-key", "ec8cca8d91msha4035d03d0a62fep1a974ejsn81cd8f210bd0");
            request.AddHeader("x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com");

            //var response = client.Execute(request);
            //Debug.WriteLine(response.Content);

            // The movie json response has no property1 which was autogenerated by VisualStudio (json to calasses),
            // instead we have to set the List<> directly for the GetAsync<>() method -> GetAsync<List<T>>().
            // Also we have to remove that class/property in the data model.
            var response = await client.GetAsync<List<MovieModel>>(request, CancellationToken.None);
            if (response == null)
                return;
            
            dGridMovies.ItemsSource = null;
            // as response is a List<> it can be used directly as a data source for the dataGrid
            dGridMovies.ItemsSource = response;     
        }
    }
}
