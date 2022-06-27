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
        public static DataView LoadDataBaseGetDefaultView()
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
        public static DataTable LoadDataBase()
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
        public static string insertData(string title, string src, string startAtSec)
        {
            string mess = "";
            string connstring = @"Integrated Security = SSPI;Initial Catalog=dbYT_Player;Data Source=LAPTOP-RGAE8HJ8\MYSQLEXPRESS";
            // insert into YoutubeSongs (title, src, startAtSec) values ('Green Day - Basket Case','NUTGr5t3MoY', 15)

            SqlConnection conn = new SqlConnection(connstring);
            string query = $"insert into YoutubeSongs (title, src, startAtSec) values ('{title}', '{src}', '{startAtSec}' )";
            //string query = $"insert into YoutubeSongs (title, src, startAtSec) values (@title, @src , @startAtSec )";
            try
            {
                SqlCommand sql = new SqlCommand(query, conn);
                conn.Open();
                sql.ExecuteNonQuery();
                mess = "geluckt";
                
            }
            catch
            {
                mess =  "is niet geluckt";
            }
            finally
            {
                conn.Close();
            }

            return mess;

            /*          
                      using (SqlCommand insertCommand = new SqlCommand(query.ToString()))
                      {
                          insertCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
                          insertCommand.Parameters.Add("@src", SqlDbType.VarChar).Value = src;
                          insertCommand.Parameters.Add("@startAtSec", SqlDbType.VarChar).Value = startAtSec;


                          SqlCommand sql = new SqlCommand(insertCommand.ToString(), conn);
                          conn.Open();
                          sql.ExecuteNonQuery();
                          conn.Close();
                      }*/


        }
        public static string insertData(string title, string src)
        {
            string mess = "";
            string connstring = @"Integrated Security = SSPI;Initial Catalog=dbYT_Player;Data Source=LAPTOP-RGAE8HJ8\MYSQLEXPRESS";
            // insert into YoutubeSongs (title, src, startAtSec) values ('Green Day - Basket Case','NUTGr5t3MoY', 15)

            SqlConnection conn = new SqlConnection(connstring);
            string query = $"insert into YoutubeSongs (title, src, startAtSec) values ('{title}', '{src}' )";
            //string query = $"insert into YoutubeSongs (title, src, startAtSec) values (@title, @src , @startAtSec )";
            try
            {
                SqlCommand sql = new SqlCommand(query, conn);
                conn.Open();
                sql.ExecuteNonQuery();
                mess = "geluckt";

            }
            catch
            {
                mess = "is niet geluckt";
            }
            finally
            {
                conn.Close();
            }

            return mess;

            /*          
                      using (SqlCommand insertCommand = new SqlCommand(query.ToString()))
                      {
                          insertCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
                          insertCommand.Parameters.Add("@src", SqlDbType.VarChar).Value = src;
                          insertCommand.Parameters.Add("@startAtSec", SqlDbType.VarChar).Value = startAtSec;


                          SqlCommand sql = new SqlCommand(insertCommand.ToString(), conn);
                          conn.Open();
                          sql.ExecuteNonQuery();
                          conn.Close();
                      }*/


        }
        public static string insertData(Video v)
        {
            string mess = "";
            string query = "";
            string connstring = @"Integrated Security = SSPI;Initial Catalog=dbYT_Player;Data Source=LAPTOP-RGAE8HJ8\MYSQLEXPRESS";
            // insert into YoutubeSongs (title, src, startAtSec) values ('Green Day - Basket Case','NUTGr5t3MoY', 15)

            SqlConnection conn = new SqlConnection(connstring);
            if(v.startAtSec != null)
            { 
                 query = $"insert into YoutubeSongs (title, src, startAtSec) values ('{v.title}', '{v.src}', {v.startAtSec} )";
            }
            else
            {
                query = $"insert into YoutubeSongs (title, src) values ('{v.title}', '{v.src}')";

            }
            //string query = $"insert into YoutubeSongs (title, src, startAtSec) values (@title, @src , @startAtSec )";
            try
            {
                SqlCommand sql = new SqlCommand(query, conn);
                conn.Open();
                sql.ExecuteNonQuery();
                mess = "succes";

            }
            catch (System.Exception ex)
            {
                mess = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return mess;

            /*          
                      using (SqlCommand insertCommand = new SqlCommand(query.ToString()))
                      {
                          insertCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
                          insertCommand.Parameters.Add("@src", SqlDbType.VarChar).Value = src;
                          insertCommand.Parameters.Add("@startAtSec", SqlDbType.VarChar).Value = startAtSec;


                          SqlCommand sql = new SqlCommand(insertCommand.ToString(), conn);
                          conn.Open();
                          sql.ExecuteNonQuery();
                          conn.Close();
                      }*/


        }



    }
}
