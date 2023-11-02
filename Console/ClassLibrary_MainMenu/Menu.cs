using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_BusinessAccessLayer;
using ClassLibrary_ProjectMenu;
namespace ClassLibrary_MainMenu

{
    public class Menu
    {
        private static readonly EmployeeBAL _empManager = new EmployeeBAL();
        private static TravelRequestBAL _trManager = new TravelRequestBAL();

        public void mainMenu()
        {

            bool continueMenu = true;
            try
            {
                do
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Enter Choice No: \n1. Manage Employee\n2. Manage Travel Request\n3. Exit");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------");
                    switch (choice)
                    {

                        case 1:
                            Console.WriteLine("Manage Employee:-");

                            ManageEmployee();
                            break;
                        case 2:
                            Console.WriteLine("Manage Travel Request:-");
                            ManageTravelRequest();
                            break;
                        case 3:
                            Console.WriteLine("Exiting the menu.");
                            continueMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Do you want to continue? (y/n)");
                    char response = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    continueMenu = (response == 'y' || response == 'Y');
                    Console.WriteLine("------------------------------------------");


                } while (continueMenu);
            } catch (Exception ex)
            {
                Console.WriteLine("Please enter correct choice...");
                Console.WriteLine(ex.Message);
            }

        }

        public void ManageEmployee()
        {

            bool continueMenu = true;
            try
            {
                do
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Enter your choice:\n1. Add Employee\n2. Edit Employee\n3. Delete Employee\n4. View Employee\n5. Go Back\n6. Exit ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------");
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Add Employee");
                            EmployeeBAL employeeBAL = new EmployeeBAL();
                            int EmpID;
                            String Emp_FName, Emp_LName, Address, Contact;
                            DateTime DOB;



                            Console.WriteLine("------------------------------");
                            Console.WriteLine("        Add Employee");
                            Console.WriteLine("------------------------------");



                            Console.WriteLine("Enter Employee ID: \n");
                            EmpID = int.Parse(Console.ReadLine());



                            Console.WriteLine("Enter FName: \n");
                            Emp_FName = Console.ReadLine();

                            Console.WriteLine("Enter LName: \n");
                            Emp_LName = Console.ReadLine();



                            Console.WriteLine("Enter Address: \n");
                            Address = Console.ReadLine();



                            Console.WriteLine("Enter Contact: \n");
                            Contact = Console.ReadLine();

                            Console.WriteLine("Enter DOB: \n");
                            DOB = DateTime.Parse(Console.ReadLine());

                            EmployeeBAL employeeBALL = new EmployeeBAL();

                            employeeBALL.AddEmployee_BAL(EmpID, Emp_FName, Emp_FName, Address, Contact, DOB);
                            Console.WriteLine("You entered {0}, {1}, {2}, {3}, {4}, {5}", EmpID, Emp_FName, Emp_LName, Address, Contact, DOB);
                            break;
                        case 2:
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Edit Employee");
                            Console.WriteLine("------------------------------");
                            _empManager.ViewAllEmployee_BAL();
                            EmployeeBAL employeeBALE = new EmployeeBAL();
                            Employee e = new Employee();
                            Console.WriteLine("Enter Id you want to change: ");
                            e.empId = int.Parse(Console.ReadLine());
                            Employee emp_to_Change = employeeBALE.GetEmpByID_BAL(e.empId);

                            Console.WriteLine("1.Edit First Name\n2.Edit Last Name\n3.Edit DOB\n4.Edit Address\n5. Edit Contact\n6. Go Back");
                            Console.WriteLine("Select Choice 1 to 7\n");
                            int choice1 = int.Parse(Console.ReadLine());
                            try
                            {
                                switch (choice1)
                                {
                                    case 1:
                                        Console.WriteLine("Edit  FName: \n");
                                        emp_to_Change.empFname = Console.ReadLine();
                                        break;

                                    case 2:
                                        Console.WriteLine("Edit LName: \n");
                                        emp_to_Change.empLName = Console.ReadLine();
                                        break;

                                    case 3:
                                        Console.WriteLine("Edit Address: \n");
                                        emp_to_Change.empAddress = Console.ReadLine();
                                        break;
                                    case 4:
                                        Console.WriteLine("Edit Contact: \n");
                                        emp_to_Change.empContactNo = Console.ReadLine();
                                        break;

                                    case 5:
                                        Console.WriteLine("Edit DOB: \n");
                                        emp_to_Change.empDob = DateTime.Parse(Console.ReadLine());
                                        break;

                                    case 6:
                                        Console.WriteLine("Go back to main");
                                        Menu menu1 = new Menu();
                                        menu1.mainMenu();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Choice");
                                        break;
                                }
                                _empManager.EditEmployee_BAL(emp_to_Change);
                                _empManager.ViewAllEmployee_BAL();
                               
                            }
                            
                            catch (Exception ex)
                            {
                                Console.WriteLine("Please enter correct choice...");
                                Console.WriteLine(ex.Message);
                            }
                             break;



                        case 3:
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Delete Employee");
                            Console.WriteLine("------------------------------");
                            EmployeeBAL employeeBALD = new EmployeeBAL();
                            _empManager.ViewAllEmployee_BAL();
                            Console.WriteLine("Enter empId you want to delete: ");
                            int id = int.Parse(Console.ReadLine());
                            employeeBALD.DeleteEmployee_BAL(id);
                            break;
                        case 4:
                            Console.WriteLine("View Employee");
                            EmployeeBAL employeeBALV = new EmployeeBAL();
                            employeeBALV.ViewAllEmployee_BAL();

                            break;
                        case 5:
                            Console.WriteLine("Go Back");
                            Menu menu = new Menu();
                            menu.mainMenu();
                            break;
                        case 6:
                            Console.WriteLine("Exiting the menu now");
                            continueMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue? (y/n)");
                    char response = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    continueMenu = (response == 'y' || response == 'Y');
                    Console.WriteLine("------------------------------------------");

                } while (continueMenu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter correct choice...");
                Console.WriteLine(ex.Message);
            }

        } 
        public void ManageTravelRequest()
        {
            bool continueMenu = true;
 
                do
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Manage Travel Request");
                    Console.WriteLine("Enter your choice: \n1. Raise travel request\n2. View travel request\n3. Delete travel request\n4. Approve travel \n5. Confirm Booking\n6. Edit Travel Request\n7. View All Approved Travel Requests\n8. View All Pending Travel Requests\n9. View All Denied Travel Requests\n10. View All Confirmed Travel Requests\n11. View All Open Travel Requests\n12. View All From Perticular Location Travel Request\n13. View All To Perticular Location Requests\n14. Go back\n15. Exit");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Raise travel request");
                            TravelRequestBAL trBAL = new TravelRequestBAL();
                            int reqId, empId;
                            String location_from, location_to;
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("        Raise Travel Request        ");
                            Console.WriteLine("------------------------------");

                            Console.WriteLine("Enter Request ID: \n");
                            reqId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Employee ID: \n");
                            empId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Location form: \n");
                            location_from = Console.ReadLine();

                            Console.WriteLine("Enter Location to: \n");
                            location_to = Console.ReadLine();
                            trBAL.RaiseRequest_BAL(reqId, empId, location_from, location_to, approveS.NA, confirmB.Not_Confirmed, currentS.Open);
                            Console.WriteLine("You entered {0}, {1}, {2}, {3}", reqId, empId, location_from, location_to, approveS.NA, confirmB.Not_Confirmed, currentS.Open);

                            break;
                        case 2:
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("View  travel requests");
                        Console.WriteLine("------------------------------");
                        _trManager.ViewAllRequest_BAL();
                        Console.WriteLine();
                        Console.WriteLine("------------------------------");
                            Console.WriteLine("View Joint List");
                            Console.WriteLine("------------------------------");
                            _trManager.ViewJoinReqTable_BAL();
                            break;
                        case 3:
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Delete travel request");
                            Console.WriteLine("------------------------------");
                            TravelRequestBAL trBALD = new TravelRequestBAL();
                            _trManager.ViewAllRequest_BAL();
                            Console.WriteLine("Enter reqId you want to delete: ");
                            int id = int.Parse(Console.ReadLine());
                            trBALD.DeleteRequest_BAL(id);
                            break;
                        case 4:

                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Approve request");
                            Console.WriteLine("------------------------------");
                            TravelRequestBAL trBALA = new TravelRequestBAL();
                            _trManager.ViewPendingRequests_BAL();
                            Console.WriteLine("Enter reqId you want to approve or deny: ");
                            int rid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter 1 if  you want to approve and 0 if you want to deny: ");
                            int aord = int.Parse(Console.ReadLine());
                            approveS approve_status = approveS.NA;
                            currentS current_status = currentS.Close;
                            if (aord == 1)
                            {
                               // approve_status = approveS.Approved;
                               // current_status = currentS.Open;
                                trBALA.ApproveStatus_BAL(rid,approveS.Approved, currentS.Open);
                            }
                            else if (aord == 0)
                            {
                                //approve_status = approveS.Denied;
                                //current_status = currentS.Close;
                                trBALA.ApproveStatus_BAL(rid, approveS.Denied, currentS.Close);
                                //trBALA.ViewNotApprovedRequests_BAL();

                            }
                            
                            break;
                        case 5:
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Confirm booking");
                            Console.WriteLine("------------------------------");
                            TravelRequestBAL trBALC = new TravelRequestBAL();
                            try
                            {
                                _trManager.ViewApprovedRequests_BAL();
                                Console.WriteLine("Enter reqId you want to confirm booking of: ");
                                int r_id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter 1 if  you want to confirm booking of and 0 if you dont want to confirm booking of: ");
                                int corn = int.Parse(Console.ReadLine());
                                confirmB confirm_booking = confirmB.Not_Confirmed;
                                current_status = currentS.Open;
                                if (corn == 1)
                                {
                                    //confirm_booking = confirmB.Confirmed;
                                    //current_status = currentS.Close;
                                trBALC.ConfirmBooking_BAL(r_id, confirmB.Confirmed, currentS.Close);
                            }
                                else if (corn == 0)
                                {
                                //confirm_booking = confirmB.Not_Confirmed;
                                //current_status = currentS.Close;
                                trBALC.ConfirmBooking_BAL(r_id, confirmB.Not_Confirmed, currentS.Close);
                            }
                                
                            }catch(Exception ex)
                            {
                                Console.WriteLine("Please enter correct choice from above table...");
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 6:
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Edit travel request");
                            Console.WriteLine("------------------------------");
                            _trManager.ViewAllRequest_BAL();
                            TravelRequestBAL employeeBALE = new TravelRequestBAL();
                            TravelRequest e = new TravelRequest();
                            Console.WriteLine("Enter Id you want to change: ");
                            e.reqId = int.Parse(Console.ReadLine());
                            TravelRequest emp_to_Change = employeeBALE.GetReqByID_BAL(e.reqId);
                            Console.WriteLine("1.Edit Emp Id\n2.Edit Location from\n3.Edit Location to\n4.Go Back");
                            Console.WriteLine("Select Choice 1 to 7\n");
                            int choice1 = int.Parse(Console.ReadLine());
                            switch (choice1)
                            {
                                case 1:
                                    Console.WriteLine("Edit  Emp Id: \n");
                                    emp_to_Change.empId = int.Parse(Console.ReadLine());
                                    break;
                                case 2:
                                    Console.WriteLine("Edit Location from: \n");
                                    emp_to_Change.location_from = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Edit Location to: \n");
                                    emp_to_Change.location_from = Console.ReadLine();
                                    break;

                                case 4:
                                    Console.WriteLine("Go back to main");
                                    Menu menu1 = new Menu();
                                    menu1.mainMenu();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }


                            _trManager.EditRequest_BAL(emp_to_Change);
                            _trManager.ViewConfirmedRequests_BAL();
                            break;
                        case 7:
                            Console.WriteLine("View All Approved Travel Request");
                            _trManager.ViewApprovedRequests_BAL();
                            break;
                        case 8:
                            Console.WriteLine("View All Pending Travel Request");
                            _trManager.ViewPendingRequests_BAL();
                            break;
                        case 9:
                            Console.WriteLine("View All Denied Travel Request");
                            _trManager.ViewNotApprovedRequests_BAL();
                            break;
                        case 10:
                            Console.WriteLine("View All Confirmed Travel Request");
                            _trManager.ViewConfirmedRequests_BAL();
                            break;
                        case 11:
                            Console.WriteLine("View All Open Travel Request");
                            _trManager.ViewOpenRequests_BAL();
                            break;
                        case 12:
                            Console.WriteLine("View All From Perticular Location Travel Request");
                            Console.WriteLine("Enter from_location : ");
                            string fromLocation = Console.ReadLine();
                            _trManager.ViewFromPerticularLocationRequests_BAL(fromLocation);
                            break;
                        case 13:
                            Console.WriteLine("View All To Perticular Location Travel Request");
                            Console.WriteLine("Enter to_location : ");
                            string toLocation= Console.ReadLine();
                            _trManager.ViewToPerticularLocationRequests_BAL(toLocation);
                            break;
                        case 14:
                            Console.WriteLine("Go back");
                            Menu menu = new Menu();
                            menu.mainMenu();
                            break;
                        case 15:
                            Console.WriteLine("Exiting the menu...");
                            continueMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue? (y/n)");
                    char response = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    continueMenu = (response == 'y' || response == 'Y');
                    Console.WriteLine("------------------------------------------");
                } while (continueMenu);
            
        }
    }
}
