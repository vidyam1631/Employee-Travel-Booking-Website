using ClassLibrary_ProjectMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_BusinessAccessLayer;
using ClassLibrary_DataAccessLayer;
using static ClassLibrary_ProjectMenu.MainMenu;

namespace ClassLibrary_BusinessAccessLayer
{
    public class TravelRequestBAL : ITravelRequestBAL
        
    {
        private static readonly TravelRequestDataManager _trManager= new TravelRequestDataManager();
        public int RaiseRequest_BAL(int reqId, int empId, string location_from, string location_to, approveS approveStatus, confirmB confirmBooking, currentS currentStatus)
        {
            _trManager.RaiseRequest_DAL(reqId, empId, location_from, location_to, approveStatus, confirmBooking, currentStatus);
            return 1;
        }
        public int EditRequest_BAL(TravelRequest travelRequest)
        {
            _trManager.EditRequest_DAL(travelRequest);
            return 1;
        }
        public int DeleteRequest_BAL(int reqId)
        {
            _trManager.DeleteRequest_DAL(reqId);
            return 1;
        }
        public int ApproveStatus_BAL(int reqId, approveS approve_status,currentS current_status1)
        {
            _trManager.ApproveStatus_DAL(reqId, approve_status, current_status1);
            return 1; 
        }
        public int ConfirmBooking_BAL(int reqId, confirmB confirm_booking,currentS current_status)
        {
            _trManager.ConfirmBooking_DAL(reqId, confirm_booking, current_status);
            return 1;
        }
        public void ViewAllRequest_BAL()
        {
            _trManager.ViewAllRequest_DAL();
        }
        public int ViewJoinReqTable_BAL()
        {
            _trManager.ViewJoinReqTable_DAL();
            return 1;
        }
        public int ViewApprovedRequests_BAL()
        {
            _trManager.ViewApprovedRequests_DAL();
            return 1;
        }
        public int ViewConfirmedRequests_BAL()
        {
            _trManager.ViewConfirmedRequests_DAL();
            return 1;
        }
        public int ViewPendingRequests_BAL()
        {
            _trManager.ViewPendingRequests_DAL();
            return 1;
        }
        public int ViewFromPerticularLocationRequests_BAL(string fromLocation)
        {
            _trManager.ViewFromPerticularLocationRequests_DAL(fromLocation);
            return 1;
        }
        public int ViewToPerticularLocationRequests_BAL(string locationto)
        {
            _trManager.ViewToPerticularLocationRequests_DAL(locationto);
            return 1;
        }
        public int ViewNotApprovedRequests_BAL()
        {
            _trManager.ViewNotApprovedRequests_DAL();
            return 1;
        }
        public int ViewOpenRequests_BAL()
        {
            _trManager.ViewOpenRequests_DAL();
            return 1;
        }
        public TravelRequest GetReqByID_BAL(int reqId)
        {
            TravelRequest r=_trManager.GetReqByID_DAL(reqId);
            return r;
        }
    }
}






































