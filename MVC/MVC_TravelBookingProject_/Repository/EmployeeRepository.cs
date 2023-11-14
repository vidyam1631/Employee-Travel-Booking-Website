using MVC_TravelBookingProject_.Models;

namespace MVC_TravelBookingProject_.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly TicketBooking_DbContext _ticketbooking;
        public EmployeeRepository(TicketBooking_DbContext ticketbooking)
        {
            _ticketbooking = ticketbooking;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _ticketbooking.Employees;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _ticketbooking.Add(employee);
                    _ticketbooking.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.ToString()}");
            }

        }
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee e = _ticketbooking.Employees.FirstOrDefault(x => x.EmpId == id);
                if (e != null)
                {
                    _ticketbooking.Employees.Remove(e);
                    _ticketbooking.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.ToString()}");
            }
        }
        public Employee GetEmployeeByid(int id)
        {
            Employee e = _ticketbooking.Employees.FirstOrDefault(x => x.EmpId == id);
            return e;
        }
        public void UpdateEmployee(int id, Employee e)
        {
            Employee? emp_old = _ticketbooking.Employees.FirstOrDefault(c => c.EmpId == id);
            if (emp_old != null)
            {
                emp_old.EmpFname = e.EmpFname;
                emp_old.EmpLname = e.EmpLname;
                emp_old.EmpAddress = e.EmpAddress;
                emp_old.EmpContact = e.EmpContact;
                emp_old.EmpDob = e.EmpDob;
                _ticketbooking.SaveChanges();
            }
        }
    }
}
