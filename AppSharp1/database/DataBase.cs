using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace AppSharp1
{
    public class DataBase
    {
        private static readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=App1DB";
        public static NpgsqlConnection Connection { get; private set; }

        public static void Connect()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
            {
                return;
            }

            Connection = new NpgsqlConnection(connectionString);

            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(1);
            }
        }

        public static void Disconnect()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
