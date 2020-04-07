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
    }
}
