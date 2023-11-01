using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ProjectMenu
{
    public class Employee
    {
        
        public  int empId { get; set; }
        public string empFname { get; set; }
        public string empLName { get; set; }
         public string empAddress { get; set; }
        public string empContactNo { get; set; }
         public DateTime empDob { get; set; }
        //public Employee(int id, string fname, string lname, string address,string contactno,DateTime dob)
        //{
        //    empId = id;
          //  empFname = fname;
          //empLName = lname;
       //     empAddress = address;
         //   empContactNo = contactno;
        //    empDob = dob;
        //}

        public override string ToString()
        {
            //return string.Format( "Id: {0}, First Name: {1}, Last Name: {2}, Address: {3}, Contact No: {4}, Dob: {5}",empId,empFname, empLName, empAddress, empContactNo, empDob);
            //Console.WriteLine("*******************Employee Management*******************");
            //return string.Format("ReqId: {0}, EmpId: {1}, location_form: {2}, location_to: {3},  approve_status {4}, confirm_status: {5}, current_status",reqId, empId, location_from, location_to, approve_status, confirm_booking, current_status);
            //Console.WriteLine("-----------------------------------------------------------------------------------------------");
            return string.Format("{0,-10} {1,-10} {2,-12} {3,-15} {4,-15} {5,-20}", empId, empFname, empLName, empAddress, empContactNo, empDob);
            //Console.WriteLine("------------------------------------------------------------------------------------------------");
            //Console.WriteLine("{0,-10} \t{1,-10}   \t{2,-10} \t{3,-10} \t{4,-10} \t{5,-10}", empId, empFname, empLName, empAddress, empContactNo, empDob);
            //Console.WriteLine();
            //return string.Empty;
        }

        
    }
}
