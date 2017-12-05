using System;

using Xamarin.Forms;

namespace Aerococina
{
    public partial class App : Application
    {
        public static string RutaDB;

        public App(string rutaDB)
        {
            InitializeComponent();
            RutaDB = rutaDB;
            Services.SqliteService.CrearTablas();
            MainPage = new NavigationPage(new Views.Security.Login())
            { BarBackgroundColor = Color.FromHex("#003454")};
        }
    }
}
