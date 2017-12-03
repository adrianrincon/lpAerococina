using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            void Handle_Clicked(object sender, System.EventArgs e)
            {
                RemoveProperties();
                //App.Current.MainPage = new Paginas.Seguridad.Login();
            }

            void RemoveProperties()
            {
                try
                {
                    App.Current.Properties.Remove("UsuarioId");
                    App.Current.Properties.Remove("Nombre");
                    App.Current.Properties.Remove("Estatus");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
}
