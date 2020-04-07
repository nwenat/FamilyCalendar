using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.Models
{
    public class MockEventRepository : IEventRepository
    {
        private List<Event> _eventList;

        public MockEventRepository()
        {
            _eventList = new List<Event>()
            {
                new Event() {Id = 1, UserId = 1, Name = "Praca",  From = new DateTime(2020, 4, 1, 7, 0, 0), To = new DateTime(2020, 4, 1, 15, 0, 0)},
            };
        }

        public IEnumerable<Event> GetAllEvent()
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
