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
