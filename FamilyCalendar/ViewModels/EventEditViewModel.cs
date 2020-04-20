using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.ViewModels
{
    public class EventEditViewModel : EventCrateViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
