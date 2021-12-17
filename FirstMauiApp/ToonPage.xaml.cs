using System;
using System.Text.Json;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace FirstMauiApp
{
	public partial class ToonPage : ContentPage
	{
		public ToonPage()
		{
			InitializeComponent();
            GetToonsAsync();
        }

        public async void GetToonsAsync()
        {
            HttpClient client = new HttpClient();
            var stream = client.GetStreamAsync("https://api4all.azurewebsites.net/api/people");
            var data = await JsonSerializer.DeserializeAsync<Toon[]>(await stream);
            Dispatcher.Dispatch(() => cvToons.ItemsSource = data);
        }


    }
}