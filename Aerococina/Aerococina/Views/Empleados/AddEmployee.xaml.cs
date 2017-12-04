using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aerococina.Views.Empleados
{
    public partial class AddEmployee : ContentPage
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var hud = DependencyService.Get<IHud>();
            try
            {
                var user = (Models.User)App.Current.Properties["user"];
                if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtEmployeeNumber.Text))
                {
                    hud.ShowLoading();
                    var employee = new Models.Employee()
                    {
                        CompanyId = user.CompanyId,
                        Email = string.Empty,
                        EmployeeNumber = txtEmployeeNumber.Text,
                        EmployeeId = 0,
                        Name = txtName.Text.Trim().ToUpper(),
                        RegistrationDate = DateTime.Now,
                        Status = true
                    };
                    var itemResult = await Controller.EmployeeController.AddEmployee(employee);
                    if (itemResult.Result)
                    {
                        hud.Cancel();
                        hud.ShowSuccessWithMessage("Guardado Correctamente");
                        SendBackButtonPressed();
                    }
                    else
                    {
                        hud.Cancel();
                        hud.ShowErrorMessage(itemResult.Message); 
                    }
                }
                else
                    hud.ShowErrorMessage("Todos los campos son requeridos");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
