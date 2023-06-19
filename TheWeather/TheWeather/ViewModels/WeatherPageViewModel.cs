using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheWeather.Models;
using Xamarin.Forms;

namespace TheWeather.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        private WeatherData data;
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion
        public WeatherData Data
        {
            get => data; 
            set
            {
                data = value;
                OnProperyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }

        public WeatherPageViewModel()
        {
            SearchCommand = new Command(async (searchTerm) =>
            {
                //x,y
                var entrada = searchTerm as string;
                var datos = entrada.Split(',');
                var lat = datos[0];
                var lon = datos[1];
                await GetData($"https://api.weatherbit.io/v2.0/current?lat={lat}&lon={lon}&key=c84d41b368ea4ad09ff4cd04038a51d2&lang=es");
            });
        }



        private async Task GetData(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherData>(jsonResult);
            Data = result;
        }
    }
}
