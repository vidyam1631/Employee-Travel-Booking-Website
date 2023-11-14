using Microsoft.AspNetCore.Mvc;
using MVC_TravelBookingProject_.Models;
using MVC_TravelBookingProject_.Repository;

namespace MVC_TravelBookingProject_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _emR;
        public EmployeeController(IEmployeeRepository emR)
        {
            _emR = emR;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _emR.GetAllEmployees();
            return View(employees);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {

            if (ModelState.IsValid)
            {
                //Console.WriteLine("In Add  product" + p.Name);
                _emR.AddEmployee(e);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            if (id != null)
            {
                _emR.DeleteEmployee(id);
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployee(int id)
        {
            Employee e = _emR.GetEmployeeByid(id);

            return View(e);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(int id, Employee e)
        {
            if (ModelState.IsValid)
            {
                _emR.UpdateEmployee(id, e);
            }
            return RedirectToAction("Index");

        }
    }
}
