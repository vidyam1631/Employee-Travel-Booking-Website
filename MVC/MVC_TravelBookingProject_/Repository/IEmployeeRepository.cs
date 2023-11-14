using MVC_TravelBookingProject_.Models;

namespace MVC_TravelBookingProject_.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee e);
        void DeleteEmployee(int id);
        Employee GetEmployeeByid(int id);
        void UpdateEmployee(int id, Employee e);
    }
}
