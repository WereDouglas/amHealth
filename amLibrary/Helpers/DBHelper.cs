﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amLibrary.Helpers
{
    public class DBHelper
    {
        public string Database { get; set; }
        public string Server { get; set; }
        //  public static SqlCeConnection con = new SqlCeConnection(@"Data Source="+ System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\wimea.sdf;Password=wimea; Persist Security Info=True;");
        //ConnectionString = "Data Source=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Database.sdf"s

        public string conString = @"Data Source=c:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;";
        public SqlCeConnection con;
        

        public DBHelper()
        {
            con = new SqlCeConnection(conString);
        }

        public void ExecuteNonQuery(string Query)
        {
            openConnection();
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection();

            }


        }

        public void ExecuteNonQuery(SqlCeCommand cmd)
        {
            openConnection();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection();
            }


        }

        public void ExecuteQuery(string Query, DataTable table)
        {
            SqlCeCommand cmd;
            SqlCeDataAdapter adapter;
            using (SqlCeConnection conn = new SqlCeConnection(conString))
            {
                conn.Open();
                cmd = new SqlCeCommand();
                adapter = new SqlCeDataAdapter();
                cmd.CommandText = Query;
                cmd.Connection = conn;
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
            }
        }

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State != System.Data.ConnectionState.Closed)
                con.Close();
        }

    }

}
