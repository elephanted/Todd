using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Todd.Domain;
using Todd.Interfaces;
using Microsoft.Owin.Host;
using Microsoft.Owin;
using System.Net;

namespace Todd.Web.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        const string apiUrl = @"http://localhost:65139/api/Calendar";

        public ActionResult Calendar()
        {
            string values = "";
            IEnumerable<Calendar> viewModel;
            client.BaseAddress = new Uri("http://localhost:65139");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Calendar").Result;
            if (response.IsSuccessStatusCode)
            {
                var yourcustomobjects = response.Content.ReadAsAsync<IEnumerable<Calendar>>().Result;
                viewModel = yourcustomobjects.ToList();
                foreach (var x in yourcustomobjects)
                {
                    //Call your store method and pass in your own object
                    values += x.CalendarName + " - ";
                }
                ViewBag.Values = values;
                return View(viewModel);
            }
            else
            {
                //Something has gone wrong, handle it here
            }

            ViewBag.Values = values;
            return View();
        }

        public ActionResult Values()
        {
            string values = "";
            client.BaseAddress = new Uri("http://localhost:65139");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/values").Result;
            if (response.IsSuccessStatusCode)
            {
                var yourcustomobjects = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
                foreach (var x in yourcustomobjects)
                {
                    //Call your store method and pass in your own object
                    values += x + " - ";
                }
            }
            else
            {
                //Something has gone wrong, handle it here
            }

            ViewBag.Values = values;

            return View();
        }
        public async Task<IEnumerable<Todd.Domain.Calendar>> GetCalendar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65139/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                IQueryable<Todd.Domain.Calendar> calendars;
                // New code:
                HttpResponseMessage response = await client.GetAsync("api/Calendar/4");
                
                    calendars = await response.Content.ReadAsAsync<IQueryable<Todd.Domain.Calendar>>();
                    return calendars;
                
               
                //Assert.AreEqual("Resource Availability Calendar", calendar.CalendarName);
            }
        }

    }

    
}
