using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinnesLayerAsModel
{
    public class SQLTools
    {
        private static SqlConnection Connection;
        private static SqlDataAdapter Adapter;
        private static SqlCommand Command;

        public static void connect()
        {            
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BusinessObjectModel"].ConnectionString);
            Connection.Open();
        }
        public static DataTable ExecuteSelect(string SQLcommand)
        {
            Command = Connection.CreateCommand();
            Adapter = new SqlDataAdapter();
            DataTable View = new DataTable();
            Adapter.SelectCommand = Command;
            Command.CommandText = SQLcommand;
            Adapter.Fill(View);
            return View;
        }

        private static void Execute(string SQLcommand)
        {
            try
            {
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.Text;
                Command.CommandText = SQLcommand;
                Command.ExecuteNonQuery();

            }
            catch (Exception) { }
        }

        public static void ExecuteDelete(string SQLCommand)
        {
            Execute(SQLCommand);
        }
        public static void ExecuteInsert(string SQLCommand)
        {
            Execute(SQLCommand);
        }
        public static void ExecuteUpdate(string SQLCommand)
        {
            Execute(SQLCommand);
        }
        public static void CloseConnection()
        {
            Connection.Close();
        }

    }
}
