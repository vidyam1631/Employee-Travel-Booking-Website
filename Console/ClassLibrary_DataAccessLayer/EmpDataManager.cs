using ClassLibrary_ProjectMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary_DataAccessLayer
{
    public class EmpDataManager:IEmpDataManager
    {
        public List<Employee> lstemployees = new List<Employee>()
         {
                new Employee() { empId = 1, empFname = "Vidya", empLName = "Mane", empAddress = "Pune", empContactNo = "8605679406", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 2, empFname = "Akansha", empLName = "Bhagat", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 3, empFname = "Suhani", empLName = "Gaikwad", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 4, empFname = "Akansha", empLName = "Bhagat", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") },
          };


        public int AddEmployee_DAL(int empId, string empFname, string empLName, string empAddress, string empContactNo, DateTime empDob)
        {
            //Employee emp = new Employee(empId, empFname, empLname, empAddress, empContactNo, empDob);
            //Console.WriteLine(emp.ToString());

            // create a new Employee Class
            //Employee emp = new Employee(e_Id, e_Name, e_salary, e_Address, e_Contact, e_Dob);

            foreach (Employee employee in lstemployees)
            {
                if (employee.empId == empId)
                {
                    Console.WriteLine("This empId already exist cannot add another employee with same empId!!!\n");
                    return 0;
                }
                lstemployees.Add(new Employee()
                {
                    empId = empId,
                    empFname = empFname,
                    empLName = empLName,
                    empAddress = empAddress,
                    empContactNo = empContactNo,
                    empDob = empDob
                });
                ViewAllEmployee_DAL();
            }

            
            // In memory data

            //Console.WriteLine(emp.ToString());
            
            return 1;
        }
        public  Employee GetEmpByID_DAL(int empId)
        {
            Console.WriteLine("In Get Employee by Id - DAL");
            Employee Emp = lstemployees.FirstOrDefault(emp1 => emp1.empId == empId);
            if (empId != null)
            {
                return Emp;
            }
            return null;
        }
        public void EditEmployee_DAL(Employee emp)
        {
            Console.WriteLine("In Edit - DAL");
            Employee updateEmp=lstemployees.FirstOrDefault(x=>x.empId==emp.empId);
            int index=lstemployees.IndexOf(updateEmp);
            if (updateEmp != null)
            {

                lstemployees[index].empFname = emp.empFname;
                lstemployees[index].empLName= emp.empLName;
                lstemployees[index].empAddress= emp.empAddress;
                lstemployees[index].empContactNo= emp.empContactNo;
                lstemployees[index].empDob= emp.empDob;

            }
           
        }
        public void ViewAllEmployee_DAL()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View All Employees");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-18} {4,-20} {5,-20}", "EmpId", "FName", "LName", "Address", "Contact", "DOB");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (Employee employee in lstemployees)
           {
             Console.WriteLine(employee.ToString());

            }

}
        public int DeleteEmployee_DAL(int empId)
        {
            try
            {
                Console.WriteLine("In delete -DAL");
                var empD = lstemployees.Remove(lstemployees.FirstOrDefault(emp => emp.empId == empId));
                Console.WriteLine("Employee with Id {0} is deleted!!!", empId);
                ViewAllEmployee_DAL();
            } catch (FormatException ex) { Console.WriteLine(ex.Message); }
            return 1;
        }
        
    }
}

   