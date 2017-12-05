using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aerococina.Services
{
    public class SqliteService
    {
        public static void CrearTablas()
        {
            using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
            {
                con.DropTable<Models.Employee>();
                con.CreateTable<Models.Employee>();
                con.DropTable<Models.EmployeeProduct>();
                con.CreateTable<Models.EmployeeProduct>();
            }
        }

        public static async Task RefreshEmployeeProduct(int CompanyId)
        {
            #region RefreshEmployeeProduct
            try
            {
                var itemResult = await Controller.EmployeeProductController.GetListEmployeeProduct_Day(CompanyId);
                if (itemResult.Result)
                {
                    using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.RutaDB))
                    {
                        var employeeProductList = JsonConvert.DeserializeObject<List<Models.EmployeeProduct>>(itemResult.Data["Result"].ToString());
                        if (employeeProductList.Count > 0)
                        {
                            con.DeleteAll<Models.EmployeeProduct>();
                            employeeProductList.ForEach(f => con.Insert(new Models.EmployeeProduct()
                            {
                                CompanyId = f.CompanyId,
                                EmployeeId = f.EmployeeId,
                                EmployeeNumber = f.EmployeeNumber,
                                AddedToService = true,
                                CompanyDescription = f.CompanyDescription,
                                EmployeeName = f.EmployeeName,
                                EmployeeProductId = f.EmployeeProductId,
                                ProductDescription = f.ProductDescription,
                                ProductId = f.ProductId,
                                RegistrationDate = f.RegistrationDate,
                                Status = f.Status,
                                StatusDescription = f.StatusDescription
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public static async Task<bool> AgregarCatalogos(int CompanyId)
        {
            bool resultado = false;
            using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
            {
                var itemResult = await Controller.EmployeeController.EmployeeList(CompanyId);
                var itemResult2 = await Controller.EmployeeProductController.GetListEmployeeProduct_Day(CompanyId);
                if(itemResult.Result)
                {
                    var employeeList = JsonConvert.DeserializeObject<List<Models.Employee>>(itemResult.Data["Result"].ToString());
                    if(employeeList.Count >0)
                    {
                        con.DeleteAll<Models.Employee>();
                        employeeList.ForEach(f => con.Insert(f));
                    }
                    resultado = true;
                }
                if(itemResult2.Result)
                {
                    var employeeProductList = JsonConvert.DeserializeObject<List<Models.EmployeeProduct>>(itemResult2.Data["Result"].ToString());
                    if(employeeProductList.Count >0)
                    {
                        con.DeleteAll<Models.EmployeeProduct>();
                        employeeProductList.ForEach(f=> con.Insert(new Models.EmployeeProduct()
                        {
                            CompanyId=f.CompanyId,
                            EmployeeId=f.EmployeeId,
                            EmployeeNumber=f.EmployeeNumber,
                            AddedToService=true,
                            CompanyDescription=f.CompanyDescription,
                            EmployeeName=f.EmployeeName,
                            EmployeeProductId=f.EmployeeProductId,
                            ProductDescription=f.ProductDescription,
                            ProductId=f.ProductId,
                            RegistrationDate=f.RegistrationDate,
                            Status=f.Status,
                            StatusDescription=f.StatusDescription   
                        }));
                    }
                }
            }
            return resultado;
        }

    }
}
