using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
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
        public Video Get(int id)
        {
            var video = db.Videos.Find(id);
            if (video == null)
            {
                throw  new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return video;
        }

        // POST api/video
        public Video Post(Video video)
        {
            return video;
        }

        // PUT api/video/5
        public HttpResponseMessage PutVideo(int id, Video video)
        {
            if (ModelState.IsValid && id == video.VideoId)
            {
                db.Entry(video).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK,video);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }
    }
}
