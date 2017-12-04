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
                con.CreateTable<Models.Employee>();
            }
        }

        public static async Task<bool> AgregarCatalogos(int CompanyId)
        {
            bool resultado = false;
            using(SQLite.SQLiteConnection con=new SQLite.SQLiteConnection(App.RutaDB))
            {
                var itemResult = await Controller.EmployeeController.EmployeeList(CompanyId);
                if(itemResult.Result)
                {
                    var employeeList = JsonConvert.DeserializeObject<List<Models.Employee>>(itemResult.Data["Result"].ToString());
                    if(employeeList.Count >0)
                    {
                        if(employeeList.Count > con.Table<Models.Employee>().Count())
                        {
                            con.DeleteAll<Models.Employee>();
                            employeeList.ForEach(f => con.Insert(f));
                        }
                    }

                    resultado = true;
                }
            }
            return resultado;
        }
    }
}
