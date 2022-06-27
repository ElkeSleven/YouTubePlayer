using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary_YouTubePlayer
{
    public static class SQLConectionAndSelectData
    {
        public static DataView LoadDataBase()
        {
            string connstring = @"Integrated Security = SSPI;Initial Catalog=dbYT_Player;Data Source=LAPTOP-RGAE8HJ8\MYSQLEXPRESS";

            SqlConnection conn = new SqlConnection(connstring);
            string query = $"Select * from YoutubeSongs";

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;


            conn.Close();
            return dv;
        }
        public static DataTable LoadDataBase2()
        {
            string connstring = @"Integrated Security = SSPI;Initial Catalog=dbYT_Player;Data Source=LAPTOP-RGAE8HJ8\MYSQLEXPRESS";

            SqlConnection conn = new SqlConnection(connstring);
            string query = $"Select * from YoutubeSongs";

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            //DataView dv = dt.DefaultView;

            conn.Close();
            return dt;
        }



    }
}
