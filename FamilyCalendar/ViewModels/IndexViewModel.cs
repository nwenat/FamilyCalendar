using FamilyCalendar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public EventEditViewModel eventEdit { get; set; }
        public int deleteId { get; set; }
        public int page { get; set; }

        public List<SelectListItem> hourNubers { get; set; } = Enumerable.Range(0, 24).Select(n => new SelectListItem
        {
            Value = n.ToString("D2"),
            Text = n.ToString("D2")
        }).ToList();
        public List<SelectListItem> minutesNubers { get; set; } = Enumerable.Range(0, 60).Select(n => new SelectListItem
        {
            Value = n.ToString("D2"),
            Text = n.ToString("D2")
        }).ToList();
    }
}
