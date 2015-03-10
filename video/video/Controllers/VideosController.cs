﻿using System;
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
        public HttpResponseMessage Post(Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, video);
                response.Headers.Location = new Uri(Url.Link("DefaultApi",new { id = video.VideoId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
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
        public HttpResponseMessage Delete(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Videos.Remove(video);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, video);
            
        }
    }
}
