using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Todd.Domain;
using Todd.Interfaces;
using Todd.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

namespace Todd.Console
{
    class Program
    {
                     

        
        public static void Main()
        {
            EagerLoading();
        }

        public static void TestPost()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = "api/Calendar/";
            Calendar calendar2 = new Calendar();
            calendar2.CalendarName = "Testing API Calendar";
            calendar2.DateCreated = DateTime.Now;

            var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("", "login")
                });
            var result = client.PostAsync("/api/Membership/exists", content).Result;

            HttpResponseMessage response = client.PostAsJsonAsync<Calendar>(url, calendar2).Result;
            string hey = response.StatusCode.ToString();

        }

        private static void EagerLoading()
        {
            using(var context = new CalendarContext())
            {
                var eagerLoadGraph = context.Calendars.Include(c => c.AspNetUser).Include(c => c.CalendarType);
                var eagerLoadGraph1 = context.Calendars.Include(c => c.CalendarEvents);
                var eagerLoadGraph2 = context.Calendars.Include("CalendarEvents").ToList();
                var eagerLoadGraph3 = context.Calendars.Include("CalendarEvents.CalendarEventDates").ToList(); ;
                var eagerLoadGraph4 = context.Calendars.Include(c => c.AspNetUser).Include(c => c.CalendarType);
                var eagerLoadGraph5 = context.Calendars
                                    .Where(c => c.CalendarEvents.Any())
                                    .Include(c => c.CalendarEvents.Select(e => e.CalendarEventDates.Select(d => d.RepeatType)))
                                    .ToList();
                var calendar = eagerLoadGraph5;
            }
        }
    }
}
