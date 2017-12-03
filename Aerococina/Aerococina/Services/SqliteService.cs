using System;
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
    }
}
