using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PM2E146.Views;
using PM2E146.Models;

namespace PM2E146.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaSitiosPage : ContentPage
	{
		private Sitios sitios;

		public ListaSitiosPage ()
		{
			InitializeComponent ();
		}

        private void toolmenu_Clicked(object sender, EventArgs e)
        {

        }

        private void listpage_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            sitios = (Sitios)e.Item;
          

        }

        private async void btnvermapa_Clicked(object sender, EventArgs e)
        {


            try
            {
                await Navigation.PushAsync(new btnvermap(sitios.latitud, sitio.longitud, sitio.descripcion));
            }
            catch
            {
                await DisplayAlert("Advertencia", "Favor seleccione el sitio donde desea ver en el mapa", "Ok");
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listasitios.ItemsSource = await App.BaseDatos.ObtenerlistadoSitio();
        }


        private async void btneliminacasa_Clicked(object sender, EventArgs e)
        {
            try
            {
                var eliminar = await App.BaseDatos.eliminarsitio(sitios);


                if (eliminar != 0)
                {
                    await DisplayAlert("Alerta", "El Sitio fue Eliminado con Exito", "Aceptar");
                    listasitios.ItemsSource = await App.BaseDatos.ObtenerlistadoSitio();

                }
                else
                {
                    await DisplayAlert("Alerta", "Lo siento, Ha OCurrido un Problema", "Aceptar");
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Por favor seleccione el Sito que quiere elegir", "Aceptar");
            }



        }
    }
}