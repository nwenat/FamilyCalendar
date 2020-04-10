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
                new Event() {Id = 1, UserId = 1, Name = "Praca",  From = new DateTime(2020, 4, 12, 7, 0, 0), To = new DateTime(2020, 4, 12, 15, 0, 0)},
                new Event() {Id = 2, UserId = 1, Name = "Szkola",  From = new DateTime(2020, 4, 13, 7, 0, 0), To = new DateTime(2020, 4, 13, 15, 0, 0)},
                new Event() {Id = 3, UserId = 1, Name = "Granie",  From = new DateTime(2020, 4, 14, 7, 0, 0), To = new DateTime(2020, 4, 14, 15, 0, 0)},
            };
        }

        public Event Add(Event newEvent)
        {
            newEvent.Id = _eventList.Max(e => e.Id) + 1;
            _eventList.Add(newEvent);
            return newEvent;
        }

        public Event Delete(int id)
        {
            Event eventt = _eventList.FirstOrDefault(e => e.Id == id);
            if (eventt != null)
            {
                _eventList.Remove(eventt);
            }
            return eventt;
        }

        public IEnumerable<Event> GetAllEvent()
        {
            return _eventList;
        }

        public Event GetEvent(int Id)
        {
            return _eventList.FirstOrDefault(e => e.Id == Id);
        }

        public Event Update(Event eventChanges)
        {
            Event eventt = _eventList.FirstOrDefault(e => e.Id == eventChanges.Id);
            if (eventt != null)
            {
                eventt.UserId = eventChanges.UserId;
                eventt.Name = eventChanges.Name;
                eventt.From = eventChanges.From;
                eventt.To = eventChanges.To;
            }
            return eventt;
        }
    }
}
