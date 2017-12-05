using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Aerococina.Views.Empleados
{
    public partial class ListaEmpleados : ContentPage
    {
        
        public ListaEmpleados()
        {
            InitializeComponent();
            CargarListaEmpleados();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarListaEmpleados();
        }

        void Agregar_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new Views.Empleados.AddEmployee());
        }

        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            ListView lvEmployee = (ListView)sender;
            if(lvEmployee.IsRefreshing)
            {
                try
                {
                    var sessionUser = (Models.User)App.Current.Properties["user"];
                    List<ViewModels.EmployeeViewModel> employeelistViewModel = new List<ViewModels.EmployeeViewModel>();

                    Models.ItemResult itemResult = await Controller.EmployeeController.EmployeeList(sessionUser.CompanyId);
                    if (itemResult.Result)
                    {
                        List<Models.Employee> employeeList = JsonConvert.DeserializeObject<List<Models.Employee>>(itemResult.Data["Result"].ToString());
                        employeeList.ForEach(f => employeelistViewModel.Add(new ViewModels.EmployeeViewModel()
                        {
                            CompanyId = f.CompanyId,
                            Email = f.Email,
                            EmployeeId = f.EmployeeId,
                            EmployeeNumber = f.EmployeeNumber,
                            Name =f.Name,
                            Photo = f.Photo,
                            RegistrationDate = f.RegistrationDate,
                            Status = f.Status
                        }));

                        employeelv.ItemsSource = employeelistViewModel;
                        employeelv.IsRefreshing = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        async void CargarListaEmpleados()
        {
            var hud = DependencyService.Get<IHud>();
            hud.ShowLoadingWithMessage("Cargando...");
            try
            {
                var sessionUser = (Models.User)App.Current.Properties["user"];
                List<ViewModels.EmployeeViewModel> employeelistViewModel = new List<ViewModels.EmployeeViewModel>();

                Models.ItemResult itemResult = await Controller.EmployeeController.EmployeeList(sessionUser.CompanyId);
                if(itemResult.Result)
                {
                    List<Models.Employee> employeeList = JsonConvert.DeserializeObject<List<Models.Employee>>(itemResult.Data["Result"].ToString());
                    employeeList.ForEach(f=>employeelistViewModel.Add(new ViewModels.EmployeeViewModel(){
                        CompanyId=f.CompanyId,
                        Email=f.Email,
                        EmployeeId=f.EmployeeId,
                        EmployeeNumber=f.EmployeeNumber,
                        Name=f.Name,
                        Photo=f.Photo,
                        RegistrationDate=f.RegistrationDate,
                        Status=f.Status,
                        Telephone=f.Telephone
                    }));

                    employeelv.ItemsSource = employeelistViewModel;

                }
                hud.Cancel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
