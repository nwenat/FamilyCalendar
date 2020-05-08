﻿using FamilyCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.ViewModels
{
    public class WeekEventsPerUserViewModel
    {
        public SortedList<int, IEnumerable<Event>> eventsInWeek { get; set; }
        public string userName { get; set; }
    }
}
