using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.Models
{
    public class SQLEventRepository : IEventRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEventRepository> logger;

        public SQLEventRepository(AppDbContext context, ILogger<SQLEventRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Event Add(Event newEvent)
        {
            context.Events.Add(newEvent);
            context.SaveChanges();
            return newEvent;
        }

        public Event Delete(int id)
        {
            Event eevent = context.Events.Find(id);
            if (eevent != null)
            {
                context.Events.Remove(eevent);
                context.SaveChanges();
            }
            return eevent;
        }

        public IEnumerable<Event> GetAllEvent()
        {
            return context.Events;
        }

        public Event GetEvent(int Id)
        {
            return context.Events.Find(Id);
        }

        public Event Update(Event eventChanges)
        {
            var eevent = context.Events.Attach(eventChanges);
            eevent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return eventChanges;
        }
    }
}
