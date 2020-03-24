using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Jone", Department = Dept.HR, Email = "jone@gmail.com" },
                new Employee() {Id = 2, Name = "Mary", Department = Dept.IT, Email = "mary@gmail.com" },
                new Employee() {Id = 3, Name = "Clara", Department = Dept.IT, Email = "clara@gmail.com" },
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
