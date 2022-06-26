using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YT_PlayerLibrary.Business;

namespace YT_PlayerWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class YT_PlayerController : ControllerBase
    {
        [HttpGet]

        public ActionResult GetMusicVideos()
        {
            string jsonResult;
            var dt = MusicVideos.GetMusicVideos(); //Videos.LoadDataBase(); 
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
    }
}
