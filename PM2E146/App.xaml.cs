using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E146.Views;
using PM2E146.Controllers;
using PM2E146.Models;
using System.IO;

namespace PM2E146
{
    public partial class App : Application
    {
        static SitioDataBase basedatos;

        public static SitioDataBase BaseDatos
        {
            get {
                if (basedatos == null) 
                {
                    basedatos = new SitioDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BDSitios.db3"));
                }
                return basedatos;

            }

        }

        public App()
        {
            InitializeComponent();

          
            MainPage = new NavigationPage(new MainPage());
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
