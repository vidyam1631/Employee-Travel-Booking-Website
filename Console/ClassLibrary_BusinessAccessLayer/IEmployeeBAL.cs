using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_ProjectMenu;


namespace ClassLibrary_BusinessAccessLayer
{
    public interface IEmployeeBAL
    {
        int AddEmployee_BAL(int empId, string empFname, string empLname, string empAddress, string empContactNo, DateTime empDob);
        void EditEmployee_BAL(Employee employee);
        void ViewAllEmployee_BAL();
        Employee GetEmpByID_BAL(int empId);
        int DeleteEmployee_BAL(int empId);
    }
}
