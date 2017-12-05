using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Aerococina.Views
{
    public partial class MenuMaster : ContentPage
    {
        public ListView ListView;
        public MenuMaster()
        {
            InitializeComponent();
            BindingContext = new MenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Models.MenuMenuItem> MenuItems { get; set; }

            public MenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<Models.MenuMenuItem>(new[]
                {
                    new Models.MenuMenuItem { Id = 0, Title = "Captura Productos", TargetType=typeof(CapturaProductos) },
                    new Models.MenuMenuItem { Id = 1, Title = "Empleados", TargetType=typeof(Empleados.ListaEmpleados) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            int totalServiciosPorGuardar = ObtenerServicios();
            if(totalServiciosPorGuardar>0)
            {
                var respuesta = await DisplayAlert("Alerta", "Cuentas con " + totalServiciosPorGuardar + " consumos sin guardar, deseas continuar en cerrar session?", "Si", "No");
                if(respuesta)
                {
                    RemoveProperties();
                    App.Current.MainPage = new NavigationPage(new Views.Security.Login())
                    { BarBackgroundColor = Color.FromHex("#003454") };
                }
            }
            else
            {
                RemoveProperties();
                App.Current.MainPage = new NavigationPage(new Views.Security.Login())
                { BarBackgroundColor = Color.FromHex("#003454") };
            }
        }

        int ObtenerServicios()
        {
        int total = 0;
            try
            {
                using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
                {
                    total=con.Table<Models.EmployeeProduct>().Where(w=>w.AddedToService==false).ToList().Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        return total;
        }

        void RemoveProperties()
        {
            try
            {
                App.Current.Properties.Remove("user");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
