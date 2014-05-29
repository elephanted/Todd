using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todd.Data.Models;
using System.Linq;
using Todd.Domain;

namespace Todd.Test
{
    [TestClass]
    public class CalendarEventDateRepositoryTest
    {
        private CalendarEventDateAccessor accessor;
        public CalendarEventDateRepositoryTest()
        {
            this.accessor = new CalendarEventDateAccessor();
        }                

        [TestMethod]
        public void GetAllCalendarEventDatesForCalendarEventFromRepository()
        {
            //Arrange
            int id = 1;
            IQueryable<CalendarEventDate> calendarEventDates = accessor.Repo.All.Where(c=>c.CalendarEventId == id);
            //Act
            
            //Assert
            Assert.AreNotEqual(0, calendarEventDates.Count());
        }

        [TestMethod]
        public void GetCalendarEventDateByFromCalendarEventFromRepository()
        {
            //Arrange
            int calendarEventId = 1;
            IQueryable<CalendarEventDate> calendarEventDates = accessor.Repo.All.Where(c => c.CalendarEventId == calendarEventId);
            int calendarEventDateId = 4;
            CalendarEventDate calendarEventDate = calendarEventDates.FirstOrDefault(e => e.EventDateId == calendarEventDateId);
            //Act

            //Assert
            Assert.IsTrue(calendarEventDate.Wednesday.Value);
        }

        [TestMethod]
        public void UpdateCalendarEventDateFromRepository()
        {
            //Arrange
            int id = 4;
            CalendarEventDate calendarEventDate = accessor.Repo.Find(id);
            calendarEventDate.Monday = true;
            accessor.Repo.Update(calendarEventDate);
            accessor.Save();
            //Act
            CalendarEventDate calendarEventDateUpdated = accessor.Repo.Find(id);
            //Assert
            Assert.IsTrue(calendarEventDateUpdated.Monday.Value);
        }

        [TestMethod]
        public void AddCalendarEventDateWithRepository()
        {
            //Arrange
            CalendarEventDate calendarEventDate = new CalendarEventDate();
            calendarEventDate.CalendarEventId = 1;
            calendarEventDate.Repeats = true;
            var rt = new RepeatType();
            rt.RepeatTypeId = 2;
            calendarEventDate.RepeatTypeId = 2;
            calendarEventDate.Frequency = 1;
            calendarEventDate.Tuesday = true;
            calendarEventDate.StartDateTime = DateTime.Parse("2014-06-15 13:00:00.000");
            calendarEventDate.EndDateTime = DateTime.Parse("2014-06-15 15:00:00.000");
            calendarEventDate.StopDate = DateTime.Parse("2014-08-15 15:00:00.000");

            //Act
            accessor.Repo.Insert(calendarEventDate);
            accessor.Save();
            //Assert
            Assert.IsNotNull(calendarEventDate.EventDateId);
        }

        [TestMethod]
        public void DeleteCalendarEventDateWithRepository()
        {
            //Arrange
            CalendarEventDate calendarEventDate = new CalendarEventDate();
            calendarEventDate.RepeatTypeId = 2;
            calendarEventDate.CalendarEventId = 1;
            //Act
            accessor.Repo.Insert(calendarEventDate);
            accessor.Save();
            var id = calendarEventDate.EventDateId;
            Assert.IsNotNull(id, "Calendar could not be added.");
            CalendarEventDate calendarEventToDelete = accessor.Repo.Find(id);
            accessor.Repo.Delete(calendarEventToDelete);
            accessor.Save();
            CalendarEventDate calendarEventThatWasDeleted = accessor.Repo.Find(id);
            //Assert
            Assert.IsNull(calendarEventThatWasDeleted, "Calendar could not be deleted.");
        }
    }
}
