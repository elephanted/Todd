using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todd.Domain;

namespace Todd.Test.Fake
{
    class CalendarFakeDbSet:FakeDbSet<Calendar>
    {
        public override Calendar Find(params object[] keyValues)
        {
            var keyValue = (int)keyValues.FirstOrDefault();
            return this.SingleOrDefault(c => c.CalendarId == keyValue);
        }
    }
}
