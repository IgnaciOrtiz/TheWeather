using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWeather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = new WeatherPageViewModel();

        }
    }
}