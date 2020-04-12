using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.Models
{
    public interface IEventRepository
    {
        Event GetEvent(int Id);
        IEnumerable<Event> GetAllEvent();
        Event Add(Event newEvent);
        Event Update(Event eventChanges);
        Event Delete(int id);
        IEnumerable<Event> GetMondayEvents();
        SortedList<int, IEnumerable<Event>> GetWeekEvents(int dayOfWeek);
    }
}
