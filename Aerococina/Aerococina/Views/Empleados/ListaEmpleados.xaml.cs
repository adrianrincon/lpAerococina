using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Aerococina.Views.Empleados
{
    public partial class ListaEmpleados : ContentPage
    {
        List<Models.Employee> employeeList = new List<Models.Employee>();
        List<ViewModels.EmployeeViewModel> employeelistViewModel = new List<ViewModels.EmployeeViewModel>();
        public ListaEmpleados()
        {
            InitializeComponent();
            CargarListaEmpleados();
            lvEmpleados.ItemsSource = employeelistViewModel;
        }

        void Agregar_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void CargarListaEmpleados()
        {
            using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
            {
                employeeList = con.Table<Models.Employee>().ToList();
                employeeList.ForEach(f=>employeelistViewModel.Add(new ViewModels.EmployeeViewModel()
                {
                    CompanyId=f.CompanyId,
                    Email=f.Email,
                    EmployeeId=f.EmployeeId,
                    EmployeeNumber=f.EmployeeNumber,
                    Name=f.Name,
                    Photo=f.Photo,
                    RegistrationDate=f.RegistrationDate,
                    Status=f.Status,
                    StatusDescr=f.Status ? "Activo" : "Inactivo",
                    Telephone=f.Telephone
                }));
            }
        }
    }
}
