﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YT_PlayerLibrary.Entities
{
   public class Video
   {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Src { get; set; }
        public int StartAtSec { get; set; }

   }
}
