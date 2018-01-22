using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VanHackAPI;
using VanHackAPI.DTOs;

namespace VanHackAPI.Controllers
{
    [Authorize]
    public class TopicsController : ApiController
    {
        private VanHackEntities db = new VanHackEntities();

        // GET: api/Topics
        public IQueryable<TopicDTO> GetTopics()
        {
            IQueryable<TopicDTO> topics;
            var context = new VanHackEntities();
            topics = context.Topics.Select(x => new TopicDTO
            {
                Title = x.Title,
                Category = x.Category.Name,
                FullText = x.FullText,
                DateCreated = x.DateCreated,
                Username = x.AspNetUser.UserName,
                Comments = x.Comments.Select(y => new CommentDTO
                {
                    Fulltext = y.Fulltext,
                    DateCreated = y.DateCreated,
                    Edited = y.Edited,
                    Username = y.AspNetUser.UserName
                })
            });          
            
            return topics;
                                
        }

        // GET: api/Topics/5
        [ResponseType(typeof(Topic))]
        public IHttpActionResult GetTopic(int id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        // PUT: api/Topics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTopic(int id, Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topic.Id)
            {
                return BadRequest();
            }

            db.Entry(topic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Topics
        [ResponseType(typeof(Topic))]
        public IHttpActionResult PostTopic(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Topics.Add(topic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = topic.Id }, topic);
        }

        // DELETE: api/Topics/5
        [ResponseType(typeof(Topic))]
        public IHttpActionResult DeleteTopic(int id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return NotFound();
            }

            db.Topics.Remove(topic);
            db.SaveChanges();

            return Ok(topic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopicExists(int id)
        {
            return db.Topics.Count(e => e.Id == id) > 0;
        }
    }
}