using ClassLibrary_ProjectMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ClassLibrary_ProjectMenu.MainMenu;
using static ClassLibrary_ProjectMenu.TravelRequest;

namespace ClassLibrary_DataAccessLayer
{
    public class TravelRequestDataManager : IReqDataManagement
    {
        EmpDataManager empDataManager = new EmpDataManager();
        List<TravelRequest> lsttravelRequests = new List<TravelRequest>()
        {
            new TravelRequest(){reqId=101,empId=1,location_from="Pune",location_to="Hyderabad",approve_status=approveS.NA,confirm_booking=confirmB.Not_Confirmed,current_status=currentS.Open},
            new TravelRequest(){reqId=102,empId=2,location_from="Mumbai",location_to="Hyderabad",approve_status=approveS.NA,confirm_booking=confirmB.Not_Confirmed,current_status=currentS.Open},
            new TravelRequest(){reqId=103,empId=3,location_from="Hyderabad",location_to="Chennai",approve_status=approveS.NA,confirm_booking=confirmB.Not_Confirmed,current_status=currentS.Open},
            new TravelRequest(){reqId=104,empId=4,location_from="Banglore",location_to="Hyderabad",approve_status=approveS.NA,confirm_booking=confirmB.Not_Confirmed,current_status=currentS.Open },
            new TravelRequest(){reqId=105,empId=5,location_from="Mumbai",location_to="Banglore",approve_status=approveS.NA,confirm_booking=confirmB.Not_Confirmed,current_status=currentS.Open }
        };

        public int RaiseRequest_DAL(int reqId, int empId, string location_from, string location_to, approveS approveStatus, confirmB confirmBooking, currentS currentStatus)
        {
            //TravelRequest TReq = new TravelRequest(Req_Id,Emp_Id,Req_Date,From_Location,To_Location);
            //Console.WriteLine(TReq.ToString());
            foreach(TravelRequest travelRequest in lsttravelRequests)
            {
                if(travelRequest.reqId == reqId)
                {
                    Console.WriteLine("This reqId already exist you cannot add another request with the same ID!!\n");
                    return 0;
                }
              
            }
            lsttravelRequests.Add(new TravelRequest()
            { reqId = reqId, empId = empId, location_from = location_from, location_to = location_to, approve_status = approveStatus, confirm_booking = confirmBooking, current_status = currentStatus }
            );
            return 1;
        }
       
        public TravelRequest GetReqByID_DAL(int reqId)
        {
            try
            {
                TravelRequest Emp = lsttravelRequests.FirstOrDefault(emp1 => emp1.reqId == reqId);
            
                if (reqId != null)
                {
                    Console.WriteLine("In Get Travel Request by Id - DAL");
                    return Emp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter Id in required format -" + ex.Message);
               
            }
            return null;
            
    }
    
        public int EditRequest_DAL(TravelRequest travel)
   
            {
                Console.WriteLine("In Edit - DAL");
                TravelRequest updateEmp = lsttravelRequests.FirstOrDefault(x => x.reqId == travel.reqId);
                int index = lsttravelRequests.IndexOf(updateEmp);
                if (updateEmp != null)
                {
                    lsttravelRequests[index].empId = travel.empId;
                    lsttravelRequests[index].location_from = travel.location_from;
                    lsttravelRequests[index].location_to = travel.location_to;
                    lsttravelRequests[index].approve_status = travel.approve_status;
                    lsttravelRequests[index].confirm_booking = travel.confirm_booking;
                }

            
            return 1;
         }
     public int DeleteRequest_DAL(int reqId)
    {
            try
            {
                Console.WriteLine("In Delete - DAL");
                ViewAllRequest_DAL();
                var req = lsttravelRequests.Remove(lsttravelRequests.FirstOrDefault(emp => emp.reqId == reqId));
                Console.WriteLine("Employee with Id {0} is deleted!!!", reqId);
                ViewAllRequest_DAL();
            } catch(FormatException e) {
                Console.WriteLine("Please enter reqId in correct format");
                Console.WriteLine(e.Message);
            }
            return 1;
    }
      public int ApproveStatus_DAL(int reqId, approveS approve_status, currentS current_status)
    {
        Console.WriteLine("In Approve Request - DAL");
            //ViewPendingRequests_DAL();
            
            
            var approveR = lsttravelRequests.FirstOrDefault(x => x.reqId == reqId);
            approveR.approve_status = approve_status;
            approveR.current_status = current_status;

            //var req = (approveR.FirstOrDefault(emp => emp.reqId == reqId));
            //int index = lsttravelRequests.IndexOf(approveR);
            if (approveR.approve_status == approveS.Approved)
            {
                

                //lsttravelRequests[index].approve_status = approve_status;
                //lsttravelRequests[index].current_status = current_status;

                Console.WriteLine("Employee with  reqId {0} is approved!!!", reqId);
                ViewApprovedRequests_DAL();
                return 0;
            }
            else
            {
                
                ViewNotApprovedRequests_DAL();
                return 0;
            }
            return 1;
    }
    public int ConfirmBooking_DAL(int reqId, confirmB confirm_booking,currentS current_status)
    {
        Console.WriteLine("In Confirm Request - DAL");

            
            var approveR = lsttravelRequests.FirstOrDefault(x => x.reqId == reqId);
            var req = (lsttravelRequests.FirstOrDefault(emp => emp.reqId == reqId));
            bool result = req.approve_status == approveS.Approved;
            int index = lsttravelRequests.IndexOf(approveR);
            approveR.confirm_booking = confirm_booking;
            approveR.current_status = current_status;
                if (result == true)
                {
                    if (approveR.confirm_booking == confirmB.Confirmed)
                    {
                        //ViewConfirmedRequests_DAL();

                        Console.WriteLine("Employee with  reqId {0} Booking Confirmed!!!", reqId);
                        //lsttravelRequests[index].confirm_booking = confirm_booking;
                        //lsttravelRequests[index].current_status = current_status;
                        ViewConfirmedRequests_DAL();
                        return 0;
                }
                else
                {
                    Console.WriteLine("Employee with  reqId {0} Booking Not Confirmed!!!", reqId);
                    return 0;
                }
                }
                else
                {
                    Console.WriteLine("\nTravel Request is not approved yet!!");
                    return 0;
                }
           
            return 1;
    }
        public int ViewApprovedRequests_DAL()
        {
            
            
                Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                         View All Approved Travel Request");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");

                foreach (TravelRequest travelreq in lsttravelRequests)
                {
                   if(travelreq.approve_status == approveS.Approved) {
                    Console.WriteLine(travelreq.ToString());
                    }
                   
                }
            
            return 1;
        }
        public int ViewPendingRequests_DAL()
        {


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Pending Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.approve_status == approveS.NA)
                {
                    Console.WriteLine(travelreq.ToString());
                }

            }

            return 1;
        }
        public int ViewNotApprovedRequests_DAL()
        {


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Denied Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.approve_status == approveS.Denied)
                {
                    Console.WriteLine(travelreq.ToString());
                }

            }

            return 1;
        }
  
   
        public int ViewConfirmedRequests_DAL()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Confirmed Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.confirm_booking == confirmB.Confirmed)
                {
                    Console.WriteLine(travelreq.ToString());
                }

            }

            return 1;
        }
        public int ViewOpenRequests_DAL()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Open Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.current_status == currentS.Open)
                {
                    Console.WriteLine(travelreq.ToString());
                }

            }

            return 1;
        }
        public int ViewFromPerticularLocationRequests_DAL(string fromLocation)
        {


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Location From Pune Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.location_from.ToLower() == fromLocation.ToLower() )
                {
                    Console.WriteLine(travelreq.ToString());
                }
               
                    //Console.WriteLine("No request from that location");
                

            }

            return 1;
        }
        public int ViewToPerticularLocationRequests_DAL(string locationto)
        {

            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Location To Pune Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
            {
                if (travelreq.location_to.ToLower() == locationto.ToLower())
                {
                    Console.WriteLine(travelreq.ToString());
                }

            }
            //Console.WriteLine("No request to that location");
            return 1;
        }

        public int ViewJoinReqTable_DAL()
        {
            var querymethodview = from emp in empDataManager.lstemployees
                                  join req in lsttravelRequests
                                  on emp.empId equals req.empId
                                  select new
                                  {
                                      EId = emp.empId,
                                      EFName = emp.empFname,
                                      ELName = emp.empLName,
                                      EAddress = emp.empAddress,
                                      EContact = emp.empContactNo,
                                      ReqId = req.reqId,
                                      FromLocation = req.location_from,
                                      ToLocation = req.location_to,

                                  };
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Join Travel Request");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-12} |{1,-10} |{2,-10} |{3,-10} |{4,-12} |{5,-12} |{6,12} |{7,-10}|", "Emp Id", "Emp Fname", "Emp Lname", "Emp Address", "Emp Contact ", "Req Id", "Location From","Location To");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (var travelreq in querymethodview)
            {

                Console.WriteLine("|{0,-12} |{1,-10} |{2,-10} |{3,-11} |{4,-12} |{5,-12} |{6,13} |{7,-10}|", travelreq.EId, travelreq.EFName, travelreq.ELName, travelreq.EAddress, travelreq.EContact, travelreq.ReqId, travelreq.FromLocation, travelreq.ToLocation);
            }
            return 1;
        }



        public int ViewAllRequest_DAL()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         View All Travel Request                                   ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-20} {5,-20} {6,10}", "Req Id", "Emp Id", "From Loc", "To Loc", "Approve status", "Confirm booking", "Current status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (TravelRequest travelreq in lsttravelRequests)
        
            Console.WriteLine(travelreq.ToString());


        return 1;
    }


    }
}










































//////////////////////////////////////////////////////////////////////////////////////////////////
///
///
































