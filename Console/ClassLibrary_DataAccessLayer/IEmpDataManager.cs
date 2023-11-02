using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Project_Menu;
using ClassLibrary_ProjectMenu;

namespace ClassLibrary_DataAccessLayer
{
    public interface IEmpDataManager
    {
        int AddEmployee_DAL(int empId, string empFname, string empLname, string empAddress, string empContactNo, DateTime empDob);
        Employee GetEmpByID_DAL(int empId);
        void EditEmployee_DAL(Employee employee);
        void ViewAllEmployee_DAL();
        int DeleteEmployee_DAL(int empId);


    }
}
