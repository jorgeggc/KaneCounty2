using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibary.DataAccess
{
    public class SqlDataAccess
    {
        private SqlConnection conn;
        public SqlConnection getConnection()
        {
            String connStr = @"Data Source=(local)\sqlexpress;Database=BuildingAccess;Integrated Security = True;";
            conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public SqlDataReader getReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.conn;

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;            
        }

        public void closeConnection()
        {
            if(conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }
        
        //public static int SaveData<T>(string sql, T data)
        //{
        //    using (IDbConnection cnn = new SqlConnection(conn))
        //    {
        //        return cnn.Execute(sql, data);
        //    }
        //}
    }
}
