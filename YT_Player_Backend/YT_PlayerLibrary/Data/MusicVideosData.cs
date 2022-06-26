using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT_PlayerLibrary.Data.Framework; //
using YT_PlayerLibrary.Entities; //
using Newtonsoft.Json;


namespace YT_PlayerLibrary.Data
{
   internal class MusicVideosData : SqlCommands, InterfaceSqlCommand<Video>
    {
        private const string tableName = "YoutubeSongs";
        public MusicVideosData() : base(tableName) { }  // naar YT_PlayerLibrary.Data.Framework
        public SelectResult select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.BaseResult;
            return result;
        }


        public SelectResult SelectQueryAll()
        {
            StringBuilder selectQuery = new StringBuilder();
            selectQuery.Append($"select * from {tableName}");


            var result = new SelectResult();
            using (SqlCommand sqlComm = new SqlCommand(selectQuery.ToString()))    // geeft de SQL query door in de vorm van een string
            {
                base.SelectRecords(sqlComm);   // 
                result = (SelectResult)base.BaseResult;

            }
            return result;
        }

    }
}
