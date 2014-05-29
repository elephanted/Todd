using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todd.Data.Models;
using System.Linq;
using Todd.Domain;

namespace Todd.Test
{
    [TestClass]
    public class CalendarEventRepositoryTest
    {
        private CalendarEventAccessor accessor;
        public CalendarEventRepositoryTest()
        {
            this.accessor = new CalendarEventAccessor();
        }                

        [TestMethod]
        public void GetAllCalendarEventsForCalendarFromRepository()
        {
            //Arrange
            int id = 4;
            IQueryable<CalendarEvent> calendarEvents = accessor.Repo.All.Where(c=>c.CalendarId == id);
            //Act
            
            //Assert
            Assert.AreNotEqual(0, calendarEvents.Count());
        }

        [TestMethod]
        public void GetCalendarEventByIdForCalendarFromRepository()
        {
            //Arrange
            int calendarId = 4;
            IQueryable<CalendarEvent> calendarEvents = accessor.Repo.All.Where(c => c.CalendarId == calendarId);
            int calendarEventId = 1;
            CalendarEvent calendarEvent = calendarEvents.FirstOrDefault(e => e.CalendarEventId == calendarEventId);
            //Act

            //Assert
            Assert.AreEqual("Meridian Availability", calendarEvent.EventName);
            Assert.AreNotEqual(0, calendarEvents.Count());
        }

        [TestMethod]
        public void UpdateCalendarEventFromRepository()
        {
            //Arrange
            CalendarEvent calendarEvent = accessor.Repo.Find(1);
            string description = "Minute Test Description: " + DateTime.Now.Millisecond.ToString();
            calendarEvent.EventDescription = description;
            accessor.Repo.Update(calendarEvent);
            accessor.Save();
            //Act
            CalendarEvent calendarEventUpdated = accessor.Repo.Find(1);
            //Assert
            Assert.AreEqual(description, calendarEvent.EventDescription);
        }

        [TestMethod]
        public void AddCalendarEventWithRepository()
        {
            //Arrange
            CalendarEvent calendarEvent = new CalendarEvent();
            calendarEvent.EventName = "Testing Calendar Event";
            calendarEvent.CalendarId = 4;
            //Act
            accessor.Repo.Insert(calendarEvent);
            accessor.Save();
            //Assert
            Assert.IsNotNull(calendarEvent.CalendarEventId);
        }

        [TestMethod]
        public void DeleteCalendarEventWithRepository()
        {
            //Arrange
            CalendarEvent calendarEvent = new CalendarEvent();
            calendarEvent.EventName = "Testing Event to Delete";
            calendarEvent.CalendarId = 4;
            //Act
            accessor.Repo.Insert(calendarEvent);
            accessor.Save();
            var id = calendarEvent.CalendarEventId;
            Assert.IsNotNull(id, "Calendar could not be added.");
            CalendarEvent calendarEventToDelete = accessor.Repo.Find(id);
            accessor.Repo.Delete(calendarEventToDelete);
            accessor.Save();
            CalendarEvent calendarEventThatWasDeleted = accessor.Repo.Find(id);
            //Assert
            Assert.IsNull(calendarEventThatWasDeleted, "Calendar could not be deleted.");
        }
    }
}
