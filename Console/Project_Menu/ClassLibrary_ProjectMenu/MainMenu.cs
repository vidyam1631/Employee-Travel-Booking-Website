using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ProjectMenu
{
    public class MainMenu
    {
        public void mainMenu()
        {

            bool continueMenu = true;
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
        }

        public void ManageEmployee()
        {
            bool continueMenu = true;
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Enter your choice: \n1. Add Employee\n2. Edit Employee\n3. Delete Employee\n4. View Employee\n5. Go Back\n6. Exit ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------");
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Employee");
                        AddEmployee();
                        break;
                    case 2:
                        Console.WriteLine("Edit Employee");
                        EditEmployee();
                        break;
                    case 3:
                        Console.WriteLine("Delete Employee");
                        DeleteEmployee();
                        break;
                    case 4:
                        Console.WriteLine("View Employee");
                        ViewEmployee();

                        break;
                    case 5:
                        Console.WriteLine("Go Back");
                        MainMenu menu = new MainMenu();
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
        public  int empId { get; set; }
         string empFname { get; set; }
         string empLName { get; set; }
         string empAddress { get; set; }
         string empContactNo { get; set; }
         DateTime empDob { get; set; }
        public  void AddEmployee()

        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Enter empId:");
            empId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter First Name:");
            empFname = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            empLName = Console.ReadLine();

            //Console.WriteLine("Enter Date of Birth (e.g., yyyy-MM-dd):");
            //if (DateTime.TryParse(Console.ReadLine()))
            //{
            //    Console.WriteLine("Enter Address:");
            //    empAddress = Console.ReadLine();

            //    Console.WriteLine("Enter Contact Number:");
            //    empContactNo = Console.ReadLine();

           // }
            //else
            //{
            //    Console.WriteLine("Invalid date format. Employee not added.");
            //}
            Console.WriteLine("------------------------------------------");
        }

        // Edit an employee (by empId)
        public void EditEmployee()
        {

            //if (employeeToEdit != null)
            Console.WriteLine("------------------------------------------");
            {
                Console.WriteLine("Enter First Name:");
                string empFname = Console.ReadLine();

                Console.WriteLine("Enter Last Name:");
                string empLName = Console.ReadLine();

                
                //else
                {
                    Console.WriteLine("Invalid date format. Employee not edited.");
                }
                Console.WriteLine("------------------------------------------");
            }
        }

        // Delete an employee (by empId)
        public static void DeleteEmployee()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Enter empId you want to delete");
            Console.WriteLine("------------------------------------------");
        }

        // View all employees
        public static void ViewEmployee()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("All Employees:");
            Console.WriteLine("------------------------------------------");

        }

         int reqId { get; set; }
        //static int empId { get; set; }
         string location_from { get; set; }
         string location_to { get; set; }
        //public enum confirm_booking { Confirmed, Not_Confirmed };
        //public enum approve_status { Approved, Denied, Pending };
        //public enum current_status { Open, Close };
         //approve_status approveS = approve_status.NA;
         //confirm_booking confirmB = confirm_booking.NA;
         //current_status currentS = current_status.open;

        public  void RaiseTravelRequest()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Raise travel request ");
            Console.WriteLine("Enter request id:");
            reqId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter employee id:");
            empId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter location form:");
            location_from = Console.ReadLine();
            Console.WriteLine("Enter location to:");
            String location_to = Console.ReadLine();

            ;
            Console.WriteLine("------------------------------------------");

        }

        public  void ViewTravelRequest()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("All travel requests");

            Console.WriteLine("Your request id:" + reqId);

            Console.WriteLine("Your employee id:" + empId);

            Console.WriteLine("Your location form:" + location_from);

            Console.WriteLine("Your location to:" + location_to);
           
            Console.WriteLine("------------------------------------------");
        }

        public  void DeleteTravelRequest()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Enter request Id of travel request that you want to Delete :");
            int delReq = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------------");
        }

        public  void ApproveRequest()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("All travel request");
            Console.WriteLine("Enter travel request Id you want to approve: ");
            int approve = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------------");

        }

        public static void ConfirmBooking()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("All travel request");
            Console.WriteLine("Enter travel request Id you want to confirm booking for: ");
            int confirm = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------------");

        }
        public  void ManageTravelRequest()
        {
            bool continueMenu = true;

            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Manage Travel Request");
                Console.WriteLine("Enter your choice: \n1. Raise travel request\n2. View travel request\n3. Delete travel request\n4. Approve travel \n5. Confirm Booking\n6. Go back\n7. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Raise travel request");
                        RaiseTravelRequest();
                        break;
                    case 2:
                        Console.WriteLine("View travel request");
                        ViewTravelRequest();
                        break;
                    case 3:
                        Console.WriteLine("Delete travel request");
                        DeleteTravelRequest();
                        break;
                    case 4:
                        Console.WriteLine("Approve request");
                        ApproveRequest();
                        break;
                    case 5:
                        Console.WriteLine("Confirm booking");
                        ConfirmBooking();
                        break;
                    case 6:
                        Console.WriteLine("Go back");
                        //MainMenu.mainMenu();
                        break;
                    case 7:
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
