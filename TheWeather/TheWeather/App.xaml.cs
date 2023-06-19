using System;
using TheWeather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheWeather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
