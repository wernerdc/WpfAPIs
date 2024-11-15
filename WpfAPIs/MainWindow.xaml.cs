using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         readonly WeatherControl _weatherControl = new WeatherControl();
        readonly NewsControl _newsControl = new NewsControl();
        readonly MoviesControl _moviesControl = new MoviesControl();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnWeather_Click(object sender, RoutedEventArgs e)
        {
            UserContentControl.Content = null;
            UserContentControl.Content = _weatherControl;
        }

        private void BtnNews_Click(object sender, RoutedEventArgs e)
        {
            UserContentControl.Content = null;
            UserContentControl.Content = _newsControl;
        }

        private void BtnFilm_Click(object sender, RoutedEventArgs e)
        {
            UserContentControl.Content = null;
            UserContentControl.Content = _moviesControl;
        }
    }
}