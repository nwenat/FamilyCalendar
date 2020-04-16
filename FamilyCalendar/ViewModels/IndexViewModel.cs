using FamilyCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.ViewModels
{
    public class IndexViewModel
    {
        public SortedList<int, IEnumerable<Event>> eventsInWeek { get; set; }
        public EventCrateViewModel eventCreate { get; set; }
    }
}
