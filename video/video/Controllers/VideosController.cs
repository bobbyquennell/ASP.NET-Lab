using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videos.Models;

namespace Videos.Controllers
{
    public class VideosController : ApiController
    {

        private VideoDb db;

        public VideosController()
        {
            db= new VideoDb();
            db.Configuration.ProxyCreationEnabled = false;

        }
        // GET api/video
        public IEnumerable<Video> GetAllVideos()
        {
            return db.Videos;
        }

        // GET api/video/5
        public string Get(int id)
        {
            return "value" + " " + id.ToString();
        }

        // POST api/video
        public Video Post(Video video)
        {
            return video;
        }

        // PUT api/video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }
    }
}
