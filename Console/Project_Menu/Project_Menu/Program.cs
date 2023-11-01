using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ClassLibrary_ProjectMenu;
//using ClassLibrary_DataAccessLayer;
using ClassLibrary_BusinessAccessLayer;
using ClassLibrary_MainMenu;


namespace Project_Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MainMenu.mainMenu();
            //EmpDataManager emp=new EmpDataManager();
            //emp.ViewAllEmployee_DAL();

            //TravelRequestDataManager request = new TravelRequestDataManager();
            //request.ViewAllRequest_DAL();
            
            //EmployeeBAL employeeBAL = new EmployeeBAL();
            //employeeBAL.ViewAllEmployee_BAL();
            //employeeBAL.DeleteEmployee_BAL(4);
             


            Menu menu = new Menu();
            menu.mainMenu();
            
            
        }
        
       
    }
    
    }


