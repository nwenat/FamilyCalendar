using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            DateTime lastMonday = new DateTime(2020, 4, 6, 0, 0, 0);
            DateTime lastTuesday = new DateTime(2020, 4, 7, 0, 0, 0);
            DateTime lastWensday = new DateTime(2020, 4, 8, 0, 0, 0);
            DateTime lastThurdsay = new DateTime(2020, 4, 9, 0, 0, 0);
            DateTime lastFriday = new DateTime(2020, 4, 6, 10, 0, 0);
            DateTime lastSaturday = new DateTime(2020, 4, 11, 0, 0, 0);
            DateTime lastSunday = new DateTime(2020, 4, 12, 0, 0, 0);

            modelBuilder.Entity<Event>().HasData(
                new Event
               {
                   Id = 1,
                   UserId = 1,
                   Name = "Praca",
                   From = lastMonday.AddHours(7),
                   To = lastMonday.AddHours(15),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 2,
                   UserId = 1,
                   Name = "Zakupy",
                   From = lastMonday.AddHours(16),
                   To = lastMonday.AddHours(17),
                   Priority = Priority.MEDIUM
               },
               new Event
               {
                   Id = 3,
                   UserId = 1,
                   Name = "Call",
                   From = lastMonday.AddHours(17),
                   To = lastMonday.AddHours(18),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 4,
                   UserId = 1,
                   Name = "Kino",
                   From = lastMonday.AddHours(20),
                   To = lastMonday.AddHours(22),
                   Priority = Priority.LOW
               },
               new Event
               {
                   Id = 5,
                   UserId = 1,
                   Name = "Praca",
                   From = lastTuesday.AddHours(7),
                   To = lastTuesday.AddHours(15),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 6,
                   UserId = 1,
                   Name = "Zakupy",
                   From = lastTuesday.AddHours(16),
                   To = lastTuesday.AddHours(17),
                   Priority = Priority.MEDIUM
               },
               new Event
               {
                   Id = 7,
                   UserId = 1,
                   Name = "Call",
                   From = lastTuesday.AddHours(17),
                   To = lastTuesday.AddHours(18),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 8,
                   UserId = 1,
                   Name = "Kino",
                   From = lastTuesday.AddHours(20),
                   To = lastTuesday.AddHours(22),
                   Priority = Priority.LOW
               },
               new Event
               {
                   Id = 9,
                   UserId = 1,
                   Name = "Praca",
                   From = lastWensday.AddHours(7),
                   To = lastWensday.AddHours(15),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 10,
                   UserId = 1,
                   Name = "Zakupy",
                   From = lastWensday.AddHours(16),
                   To = lastWensday.AddHours(17),
                   Priority = Priority.MEDIUM
               },
               new Event
               {
                   Id = 11,
                   UserId = 1,
                   Name = "Call",
                   From = lastWensday.AddHours(17),
                   To = lastWensday.AddHours(18),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 12,
                   UserId = 1,
                   Name = "Kino",
                   From = lastWensday.AddHours(20),
                   To = lastWensday.AddHours(22),
                   Priority = Priority.LOW
               },
               new Event
               {
                   Id = 13,
                   UserId = 1,
                   Name = "Praca",
                   From = lastThurdsay.AddHours(7),
                   To = lastThurdsay.AddHours(15),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 14,
                   UserId = 1,
                   Name = "Zakupy",
                   From = lastThurdsay.AddHours(16),
                   To = lastThurdsay.AddHours(17),
                   Priority = Priority.MEDIUM
               },
               new Event
               {
                   Id = 15,
                   UserId = 1,
                   Name = "Praca",
                   From = lastFriday.AddHours(7),
                   To = lastFriday.AddHours(15),
                   Priority = Priority.HIGH
               },
               new Event
               {
                   Id = 16,
                   UserId = 1,
                   Name = "Zakupy",
                   From = lastFriday.AddHours(16),
                   To = lastFriday.AddHours(17),
                   Priority = Priority.MEDIUM
               },
               new Event
               {
                   Id = 17,
                   UserId = 1,
                   Name = "Odpoczynek",
                   From = lastSaturday.AddHours(16),
                   To = lastSaturday.AddHours(17),
                   Priority = Priority.MEDIUM
               },
               new Event
               {
                   Id = 18,
                   UserId = 1,
                   Name = "Basen",
                   From = lastSunday.AddHours(16),
                   To = lastSunday.AddHours(17),
                   Priority = Priority.MEDIUM
               }
               );

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Mary",
                   Department = Dept.IT,
                   Email = "mary@gmail.com"
               },
               new Employee
               {
                   Id = 2,
                   Name = "John",
                   Department = Dept.Payroll,
                   Email = "john@gmail.com"
               }
               );
        }
    }
}
