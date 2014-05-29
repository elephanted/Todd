using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todd.Data.Models;
using System.Linq;
using Todd.Domain;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Web.Http.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Hosting;

namespace Todd.Test
{
    [TestClass]
    public class CalendarAPITest
    {
        public async Task GetCalendar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65139/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Calendar calendar;
                // New code:
                HttpResponseMessage response = await client.GetAsync("api/Calendar/4");
                if (response.IsSuccessStatusCode)
                {
                    calendar = await response.Content.ReadAsAsync<Calendar>();
                }
                else
                {
                    calendar = new Calendar();
                }
                Assert.AreEqual("Resource Availability Calendar", calendar.CalendarName);
            }
        }

        [TestMethod]
        public void GetAllCalendarsFromAPIdoestntwork()
        {
            GetCalendar().Wait();
        }

        [TestMethod]
        public void GetCalendarsFromAPISelfHost()
        {
            string baseAddress = "http://localhost:9000/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();
                string values = "";
                IEnumerable<Calendar> viewModel;
                client.BaseAddress = new Uri("http://localhost:9000");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Calendar").Result;
                if (response.IsSuccessStatusCode)
                {
                    var yourcustomobjects = response.Content.ReadAsAsync<IEnumerable<Calendar>>().Result;
                    viewModel = yourcustomobjects.ToList();
                    foreach (var x in yourcustomobjects)
                    {
                        //Call your store method and pass in your own object
                        values += x + " - ";
                        Assert.AreNotEqual(0, viewModel.Count());
                    }
                }
                else
                {
                    //Something has gone wrong, handle it here
                    Assert.Fail("Yep.");
                }                    
            }
        }

        [TestMethod]
        public void GetAllCalendarsFromAPI()
        {
             

            HttpClient client = new HttpClient();
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
                Assert.AreNotEqual(0, viewModel.Count());
                
            }
            else
            {
                //Something has gone wrong, handle it here
            }

        }
    }
}
