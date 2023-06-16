using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Plugin.Media;

namespace PM2E146.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapaPage : ContentPage
	{
		String latitudM, longitudM, descripcionM;
		public MapaPage (String Latitud, String Longitud, String Descripcion)
		{
			InitializeComponent ();
			latitudM = Latitud;
			longitudM = Longitud;
			descripcionM = Descripcion;
		}

		private async async btnCompartirUbicacion_Clicked(object sender, EventArgs e)
		{
			try
			{
				await Share.RequestAsync(
					new ShareTextRequest
					{
						Title = "Compartiendo Ubicacion",
						Text = "Te Comparto Mi Ubicacion",
						Uri = "https://maps.google.com/?q="+longitudM+","+latitudM
					}

					);
			}
			catch { 

			}

		}

		private void toolmenu_Clicked(object sender, EventArgs e)
		{

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

			var localization = Geolocation.GetLocationAsync();
			if( localization != null )
			{
				DisplayAlert("Alerta", "Tiene desactivado su GPS", "OK");
			}

			Pin ubication = new Pin();
			ubication.Label = descripcionM.ToString();
			ubication.Type = PinType.Place;
			ubication.Position = new Position(Double.Parse(longitudM), Double.Parse(latitudM));
			Map.Pins.Add(ubication);
			Map.IsShowingUser = true;
			Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Double.Parse(longitudM),
			Double.Parse(latitudM)), Distance.FromMeters(400.0)));

        }
    }
}