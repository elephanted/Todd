using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Todd.Domain;
using Todd.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using System.Net.Http.Formatting;

namespace Todd.Web.Controllers
{
    public class CalController : Controller
    {
        private ToddEntities db = new ToddEntities();
        HttpClient client;               

        public CalController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
        }      

        // GET: /Cal/
        public ActionResult Index()
        {
            string url = "api/Calendar";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<Calendar> viewModel = response.Content.ReadAsAsync<IEnumerable<Calendar>>().Result.ToList();
            return View(viewModel);

            //HttpClient client = new HttpClient();
            //string values = "";
            //IEnumerable<Calendar> viewModel;
            //client.BaseAddress = new Uri("http://localhost:65139");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("api/Calendar").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var yourcustomobjects = response.Content.ReadAsAsync<IEnumerable<Calendar>>().Result;
            //    viewModel = yourcustomobjects.ToList();
            //    foreach (var x in yourcustomobjects)
            //    {
            //        //Call your store method and pass in your own object
            //        values += x.CalendarName + " - ";
            //    }
            //    ViewBag.Values = values;
            //    return View(viewModel);
            //}
            //else
            //{
            //    //Something has gone wrong, handle it here
            //}

            //ViewBag.Values = values;
            //return View();

            //var calendars = db.Calendars.Include(c => c.AspNetUser).Include(c => c.CalendarType);
            //return View(calendars.ToList());
        }

        // GET: /Cal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Calendar calendar = db.Calendars.Find(id);

            string url = "api/Calendar/" + id.ToString();
            HttpResponseMessage response = client.GetAsync(url).Result;
            Calendar calendar = response.Content.ReadAsAsync<Calendar>().Result;
            
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // GET: /Cal/Create
        public ActionResult Create()
        {
            //TODO: get these ddls from the Web API, not directly from the EF.
            ViewBag.CreatedByUserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.CalendarTypeId = new SelectList(db.CalendarTypes, "CalendarTypeId", "CalendarTypeName");
            return View();
        }

        // POST: /Cal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CalendarId,CalendarName,CalendarTypeId,DateCreated,CreatedByUserId")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                string url = "api/Calendar/" ;                  
                HttpResponseMessage response = client.PostAsJsonAsync<Calendar>(url, calendar).Result;
                
                //db.Calendars.Add(calendar);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //TODO: get these ddls from the Web API, not directly from the EF.
            ViewBag.CreatedByUserId = new SelectList(db.AspNetUsers, "Id", "UserName", calendar.CreatedByUserId);
            ViewBag.CalendarTypeId = new SelectList(db.CalendarTypes, "CalendarTypeId", "CalendarTypeName", calendar.CalendarTypeId);
            return View(calendar);
        }

        // GET: /Cal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string url = "api/Calendar/" + id.ToString();
            HttpResponseMessage response = client.GetAsync(url).Result;
            Calendar calendar = response.Content.ReadAsAsync<Calendar>().Result;
            //Calendar calendar = db.Calendars.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }

            //TODO: get these ddls from the Web API, not directly from the EF.
            ViewBag.CreatedByUserId = new SelectList(db.AspNetUsers, "Id", "UserName", calendar.CreatedByUserId);
            ViewBag.CalendarTypeId = new SelectList(db.CalendarTypes, "CalendarTypeId", "CalendarTypeName", calendar.CalendarTypeId);
            return View(calendar);
        }

        // POST: /Cal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalendarId,CalendarName,CalendarTypeId,DateCreated,CreatedByUserId")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                string url = "api/Calendar/" + calendar.CalendarId.ToString();

                HttpResponseMessage response = client.PutAsJsonAsync(url, calendar).Result;
                string hey = response.StatusCode.ToString();              
                //db.Entry(calendar).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //TODO: get these ddls from the Web API, not directly from the EF.
            ViewBag.CreatedByUserId = new SelectList(db.AspNetUsers, "Id", "UserName", calendar.CreatedByUserId);
            ViewBag.CalendarTypeId = new SelectList(db.CalendarTypes, "CalendarTypeId", "CalendarTypeName", calendar.CalendarTypeId);
            return View(calendar);
        }

        // GET: /Cal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string url = "api/Calendar/" + id.ToString();
            HttpResponseMessage response = client.GetAsync(url).Result;
            Calendar calendar = response.Content.ReadAsAsync<Calendar>().Result;
            //Calendar calendar = db.Calendars.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: /Cal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Calendar calendar = db.Calendars.Find(id);
            //db.Calendars.Remove(calendar);
            //db.SaveChanges();

            string url = "api/Calendar/" + id.ToString();
            HttpResponseMessage response = client.GetAsync(url).Result;
            Calendar calendar = response.Content.ReadAsAsync<Calendar>().Result;
            string gizmoUrl = ConfigurationManager.AppSettings["baseAddress"] + "/api/Calendar/" + calendar.CalendarId.ToString();
            response = client.DeleteAsync(gizmoUrl).Result;
            string hey = response.StatusCode.ToString();


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
