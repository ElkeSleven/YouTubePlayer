using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // SqlCommands
using System.Data; //
using YT_PlayerLibrary.Settings;

namespace YT_PlayerLibrary.Data.Framework
{
    internal abstract class SqlCommands
    {
        private SqlConnection sqlConn;
        public SqlCommands(string tableName)
        {
            TableName = tableName;                                                              // tabelnaam                                                                                 // SuptableName = suptableName;                                                              // tabelnaam
            sqlConn = new SqlConnection(@"Integrated Security=SSPI;Initial Catalog=dbYT_Player;Data Source=LAPTOP-RGAE8HJ8\MYSQLEXPRESS");     // conectionstring 

        }
        protected BaseResult BaseResult { get; set; }
        protected string TableName { get; set; }

        protected void SelectRecords(SqlCommand selectCommand)   // select 
        {
            try
            {
                BaseResult = new SelectResult();
                using (sqlConn)
                {
/*                    if (string.IsNullOrEmpty(sqlConn.ConnectionString))
                        sqlConn = new SqlConnection(Settings.Settings.Database.ProjectConnectionstring);*/
                    sqlConn.Open();
                    selectCommand.Connection = sqlConn;
                    var adapter = new SqlDataAdapter(selectCommand);
                    var ds = new DataSet();
                    var dt = new DataTable();
                    BaseResult.DataTable = new System.Data.DataTable();

                    BaseResult.Rows = adapter.Fill(ds);
                    BaseResult.DataTable = ds.Tables[0];
                    BaseResult.Succeeded = true;

                }

            }
            catch (Exception ex)
            {
                // hier
                BaseResult.Adderror(ex.Message);

            }
            finally
            {
                sqlConn.Close();

            }
        }
      
        protected void SelectRecords()
        {
            try
            {
                string query = $"select * from {TableName}";
                SelectRecords(query);

            }
            catch (Exception ex)
            {

                BaseResult.Adderror(ex.Message);
            }

        }

        protected void SelectRecords(string query)
        {

            try
            {
                BaseResult = new SelectResult();
                using (SqlCommand sqlComm = new SqlCommand(query))
                {
                    SelectRecords(sqlComm);
                }
            }
            catch (Exception ex)
            {

                BaseResult.Adderror(ex.Message);
            }
            finally
            {
                sqlConn.Close();

            }
        }

    }
}
