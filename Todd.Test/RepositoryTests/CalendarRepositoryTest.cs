using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todd.Data.Models;
using System.Linq;
using Todd.Domain;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Todd.Test
{
    [TestClass]
    public class CalendarRepositoryTest
    {
        private CalendarAccessor db;
        public CalendarRepositoryTest()
        {
            this.db = new CalendarAccessor();
        }
               

        [TestMethod]
        public void GetAllCalendarsFromRepository()
        {
            //Arrange
            IQueryable<Calendar> calendars = db.Repo.All;
            //Act
            
            //Assert
            Assert.AreNotEqual(0, calendars.Count());
        }

        [TestMethod]
        public void GetCalendarByIdFromRepository()
        {
            //Arrange
            Calendar calendar = db.Repo.Find(2);
            //Act
            
            //Assert
            Assert.AreEqual("Robert's Calendar", calendar.CalendarName);
        }

        [TestMethod]
        public void UpdateCalendarFromRepository()
        {
            //Arrange
            Calendar calendar = db.Repo.Find(2);
            calendar.CalendarName = "Robert's undone Calendar";
            db.Repo.Update(calendar);
            db.Save();
            //Act
            Calendar calendarUpdated = db.Repo.Find(2);
            //Assert
            Assert.AreEqual("Robert's undone Calendar", calendarUpdated.CalendarName);
        }

        [TestMethod]
        public void AddCalendarWithRepository()
        {
            //Arrange
            Calendar calendar = new Calendar();
            calendar.CalendarName = "WTF Testing Calendar";
            calendar.DateCreated = DateTime.Now;
            //Act
            db.Repo.Insert(calendar);
            db.Save();
            //Assert
            Assert.IsNotNull(calendar.CalendarId);
        }

        [TestMethod]
        public void DeleteCalendarWithRepository()
        {
            //Arrange
            Calendar calendar = new Calendar();
            calendar.CalendarName = "Testing Calendar to Delete";
            calendar.DateCreated = DateTime.Now;
            //Act
            db.Repo.Insert(calendar);
            db.Save();
            var id = calendar.CalendarId;
            Assert.IsNotNull(id, "Calendar could not be added.");
            Calendar calendartoDelete = db.Repo.Find(id);
            db.Repo.Delete(calendartoDelete);
            db.Save();
            Calendar calendarDeleted = db.Repo.Find(id);
            //Assert
            Assert.IsNull(calendarDeleted, "Calendar could not be deleted.");
        }
    }
}
