using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Aerococina.Views.Security
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async void btnIniciarSesion_Handle_Clicked(object sender, System.EventArgs e)
        {
            var hud = DependencyService.Get<IHud>();
            hud.ShowLoadingWithMessage("Cargando...");
            if (!string.IsNullOrEmpty(txtEmail.Text) || !string.IsNullOrEmpty(txtPassword.Text))
            {
                Models.ItemResult itemResult = await Controller.SecurityController.Authenticate(txtEmail.Text, txtPassword.Text);
                if (itemResult.Result)
                {
                    Models.User itemUser = JsonConvert.DeserializeObject<Models.User>(itemResult.Data["Result"].ToString());
                    if (itemUser != null || itemUser.UserId > 0)
                    {
                        if (App.Current.Properties.Count > 0)
                            RemoveProperties();

                        var catalogsAdded = await Services.SqliteService.AgregarCatalogos(itemUser.CompanyId);
                        if(!catalogsAdded)
                        {
                            hud.Cancel();
                            hud.ShowErrorMessage("Error al cargar catalogos");
                        }

                        App.Current.Properties.Add("user", itemUser);
                        await App.Current.SavePropertiesAsync();


                        hud.Cancel();

                        App.Current.MainPage = new Views.Menu();
                    }
                    else
                        hud.ShowErrorMessage("Ocurrio un error, intente de nuevo mas tarde");
                }
                else
                    hud.ShowErrorMessage(itemResult.Message);
            }
            else
                hud.ShowErrorMessage("Todos los campos son requeridos.");

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
