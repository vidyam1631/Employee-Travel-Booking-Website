using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_DataAccessLayer;
using ClassLibrary_ProjectMenu;

namespace ClassLibrary_BusinessAccessLayer
{
    public class EmployeeBAL: IEmployeeBAL

    {
        private static readonly EmpDataManager eManager = new EmpDataManager();
        public int AddEmployee_BAL(int empId, string empFname, string empLname, string empAddress, string empContactNo, DateTime empDob)
        {
            
            eManager.AddEmployee_DAL(empId, empFname, empLname, empAddress, empContactNo, empDob);
            return 1;
        }

        public void EditEmployee_BAL(Employee employee)
        {
            
            eManager.EditEmployee_DAL(employee);
            
        }
        

        public void ViewAllEmployee_BAL()
        {
            
            eManager.ViewAllEmployee_DAL();

        }
        public Employee GetEmpByID_BAL(int empId)
        {
            
            Employee emp = eManager.GetEmpByID_DAL(empId);
            return emp;
        }
        public int DeleteEmployee_BAL(int empId)
        {
            
            eManager.DeleteEmployee_DAL(empId);
            return 1;
        }
    }
}
