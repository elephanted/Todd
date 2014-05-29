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
using Todd.Data;
using Todd.Data.Models;
using Todd.Domain;

namespace Todd.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Calendar")]
    public class CalendarController : ApiController
    {  
        private CalendarAccessor db;

        public CalendarController()
        {
            this.db = new CalendarAccessor();
        }
                
        // GET api/Calendar
        [AllowAnonymous]
        public IQueryable<Calendar> GetCalendars()
        {                     
            return db.Repo.AllIncluding().Include(c => c.AspNetUser).Include(c => c.CalendarType);
        }


        // GET api/Calendar/5
        //[ResponseType(typeof(Calendar))]
        [AllowAnonymous]
        public HttpResponseMessage GetCalendar(int id)
        {
            Calendar calendar = db.Repo.AllIncluding()
                    .Include(c => c.AspNetUser)
                    .Include(c => c.CalendarType)
                    .FirstOrDefault(c=>c.CalendarId == id);
            if (calendar == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, calendar);
        }

        // PATCH api/Calendar/5
        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage PatchCalendar(int id, Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != calendar.CalendarId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID does not match CalendarId.");
            }
                        
            try
            {
                Calendar entity = db.Repo.Find(id);
                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

               
                db.Repo.Update(calendar);
                db.Save();
                // return success
                return Request.CreateResponse(HttpStatusCode.OK, calendar);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Unable to complete the operation.");
        }

        // POST api/Calendar
        //[ResponseType(typeof(Calendar))]
        public HttpResponseMessage PostCalendar(Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                db.Repo.Insert(calendar);
                db.Save();
                //todd.Calendars.Add(calendar);
                //return Request.CreateResponse(HttpStatusCode.Created, calendar);
                return Request.CreateResponse(HttpStatusCode.OK, CreatedAtRoute("DefaultApi", new { id = calendar.CalendarId }, calendar));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

           // return CreatedAtRoute("DefaultApi", new { id = calendar.CalendarId }, calendar);
        }

        // DELETE api/Calendar/5
        //[ResponseType(typeof(Calendar))]
        public HttpResponseMessage DeleteCalendar(int id)
        {
            Calendar calendar = db.Repo.Find(id);
            if (calendar == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError { Message = "entity key " + id + " not found" });
            }

            db.Repo.Delete(calendar);
            db.Save();
            return Request.CreateResponse(HttpStatusCode.OK, calendar);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Repo.Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}