using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aerococina.Views
{
    public partial class CapturaProductos : ContentPage
    {
        public CapturaProductos()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var hud = DependencyService.Get<IHud>();
            if(!string.IsNullOrEmpty(txtEmployeeNumber.Text))
            {
                using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
                {
                    string employeeNumber = txtEmployeeNumber.Text;
                    var employee = con.Table<Models.Employee>().FirstOrDefault(f => f.EmployeeNumber == employeeNumber);
                    if (employee != null)
                    {
                        if (employee.Status)
                        {
                            txtName.Text = employee.Name;
                        }
                        else
                        {
                            DisplayAlert("Alerta", "Empleado con estatus dado de Baja", "OK");
                            txtEmployeeNumber.Text = string.Empty;
                            txtName.Text = string.Empty;
                        }
                    }
                    else
                    {
                        hud.ShowErrorMessage("Empleado no encontrado");
                        txtEmployeeNumber.Text = string.Empty;
                        txtName.Text = string.Empty;
                    }
                }
            }
            else
            {
                hud.ShowErrorMessage("Es requerido el numero de empleado");
            }
        }

        void Handle_Completed(object sender, System.EventArgs e)
        {
            var hud = DependencyService.Get<IHud>();
            if (!string.IsNullOrEmpty(txtEmployeeNumber.Text))
            {
                using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.RutaDB))
                {
                    string employeeNumber = txtEmployeeNumber.Text;
                    var employee = con.Table<Models.Employee>().FirstOrDefault(f => f.EmployeeNumber == employeeNumber);
                    if (employee != null)
                    {
                        if (employee.Status)
                        {
                            txtName.Text = employee.Name;
                        }
                        else
                        {
                            DisplayAlert("Alerta", "Empleado con estatus dado de Baja", "OK");
                            txtEmployeeNumber.Text = string.Empty;
                            txtName.Text = string.Empty;
                        }
                    }
                    else
                    {
                        hud.ShowErrorMessage("Empleado no encontrado");
                        txtEmployeeNumber.Text = string.Empty;
                        txtName.Text = string.Empty;
                    }
                }
            }
            else
            {
                hud.ShowErrorMessage("Es requerido el numero de empleado");
            }
        }
    }
}
