using ClassLibrary_YouTubePlayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_YouTubePlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetData()
        {
            string jsonResult;
            var dt = SQLConectionAndSelectData.LoadDataBase(); 
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
        [HttpPost]
        public ActionResult AddData(Video video)
        {
            string jsonResult;
            string mess = SQLConectionAndSelectData.insertData(video);
            var dt = SQLConectionAndSelectData.LoadDataBase();
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
    }
}
