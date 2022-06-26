using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YT_PlayerLibrary.Settings
{
   public static class Settings
   {
        public static class Database
        {

            private static string projConnString = @"Integrated Security = SSPI;Initial Catalog = dbYT_Player;Data Source = LAPTOP - RGAE8HJ8\\MYSQLEXPRESS";
            public static string ProjectConnectionstring => projConnString;



        }
   }
}
