using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YT_PlayerLibrary.Data; //
using YT_PlayerLibrary.Data.Framework; //
using YT_PlayerLibrary.Entities; //
using System.Data.SqlClient;
namespace YT_PlayerLibrary.Business
{
    public static class MusicVideos
    {
        public static DataTable GetMusicVideos()
        {
            var dt = new DataTable();
            try
            {
                var musicVideosData = new MusicVideosData();   
                var result = musicVideosData.SelectQueryAll();  
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }  
    }
}
