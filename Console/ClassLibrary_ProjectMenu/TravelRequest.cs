using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ProjectMenu
{
    public enum approveS { Approved, Denied, NA };
    public enum confirmB { Confirmed, Not_Confirmed, NA };
    
    public enum currentS { Open, Close };
    public class TravelRequest
    {

        public int reqId { get; set; }
        public int empId { get; set; }
        public string location_from { get; set; }
        public string location_to { get; set; }
        public approveS approve_status { get; set; }
        public confirmB confirm_booking  {  get; set; }
        
        public currentS current_status  { get; set; }
        

        public override string ToString()
        {
            //Console.WriteLine("*******************Travel Request*******************");
            return string.Format("{0,-12} {1,-10} {2,-10} {3,-12} {4,-20} {5,-20} {6,-20}",reqId, empId, location_from, location_to, approve_status, confirm_booking, current_status);
            //Console.WriteLine("-----------------------------------------------------------------------------------------------");
            //Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", "ReqId", "EmpId", "\tlocation_form\t", "approve_status\t", "confirm_status\t", "current_status\t");
            //Console.WriteLine("------------------------------------------------------------------------------------------------");
            //Console.WriteLine("{0,-10} {1,-10} \t{2,-10} \t{3,-10} \t{4,-10} \t{5,-10}", reqId, empId, location_from, location_to, approve_status, confirm_booking, current_status);
            //Console.WriteLine();
            //return string.Empty;
        }
    }
}
