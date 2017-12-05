using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Aerococina.Views
{
    public partial class CapturaProductos : ContentPage
    {
        List<Models.EmployeeProduct> listEmployeeProduct = new List<Models.EmployeeProduct>();
        public CapturaProductos()
        {
            InitializeComponent();
            lblTotalVendido.Text = ObtenerConsumos().ToString();
        }

        void Handle_Completed(object sender, System.EventArgs e)
        {
            BuscarEmpleado();
        }

        void btnProducto1_Clicked(object sender, System.EventArgs e)
        {
            #region btnProducto1_Clicked
            var hud = DependencyService.Get<IHud>();
            try
            {
                if(!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmployeeNumber.Text))
                {
                    AgregarConsumo(1);
                    lblTotalVendido.Text = ObtenerConsumos().ToString();
                    txtName.Text = string.Empty;
                    txtEmployeeNumber.Text = string.Empty;
                }
                else
                {
                    hud.ShowErrorMessage("Todos los campos son requeridos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        void btnProducto2_Clicked(object sender, System.EventArgs e)
        {
            #region btnProducto1_Clicked
            var hud = DependencyService.Get<IHud>();
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmployeeNumber.Text))
                {
                    AgregarConsumo(2);
                    lblTotalVendido.Text = ObtenerConsumos().ToString();
                    txtName.Text = string.Empty;
                    txtEmployeeNumber.Text = string.Empty;
                }
                else
                {
                    hud.ShowErrorMessage("Todos los campos son requeridos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        async void btnSubirServicios_Clicked(object sender, System.EventArgs e)
        {
            #region btnSubirServicios_Clicked
            var hud = DependencyService.Get<IHud>();
            try
            {
                var userSesion = (Models.User)App.Current.Properties["user"];
                if(listEmployeeProduct.Count > 0)
                {
                    hud.ShowLoadingWithMessage("Subiendo...");
                    var itemResult = await Controller.EmployeeProductController.AddListEmployeeProduct(listEmployeeProduct);
                    if (itemResult.Result)
                    {
                        await Services.SqliteService.RefreshEmployeeProduct(userSesion.CompanyId);
                        hud.Cancel();
                        hud.ShowSuccessWithMessage("Consumos guardados correctamente");
                        listEmployeeProduct.Clear();
                    }
                    else
                    {
                        hud.Cancel();
                        hud.ShowErrorMessage("Error al subir consumos");
                    }
                }
                else
                {
                    hud.Cancel();
                    hud.ShowErrorMessage("No hay consumos por subir");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        void BuscarEmpleado()
        {
            #region BuscarEmpleado
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
           #endregion
        }

        int ObtenerConsumos()
        {
            #region ObtenerConsumos
            int total = 0;
            try
            {
                using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
                {
                    total = con.Table<Models.EmployeeProduct>().Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return total;
            #endregion
        }

        void AgregarConsumo(int productId)
        {
            #region AgregarConsumo
            try
            {
                using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
                {
                    var userSession = (Models.User)App.Current.Properties["user"];
                    var employee = con.Table<Models.Employee>().FirstOrDefault(f => f.EmployeeNumber == txtEmployeeNumber.Text);
                    var objEmployeeProduct = new Models.EmployeeProduct()
                    {
                        CompanyId = userSession.CompanyId,
                        EmployeeId = employee != null ? employee.EmployeeId : 0,
                        EmployeeNumber=employee !=null ? employee.EmployeeNumber : string.Empty,
                        EmployeeName=employee != null ? employee.Name : string.Empty,
                        EmployeeProductId=0,
                        CompanyDescription="",
                        ProductDescription="",
                        ProductId=productId,
                        RegistrationDate=DateTime.Now,
                        Status=false,
                        StatusDescription=string.Empty,
                        AddedToService=false
                    };
                    con.Insert(objEmployeeProduct);
                    listEmployeeProduct.Add(objEmployeeProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
    }
}
