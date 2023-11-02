using ClassLibrary_ProjectMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary_ProjectMenu.MainMenu;
using static ClassLibrary_ProjectMenu.TravelRequest;

namespace ClassLibrary_DataAccessLayer
{
    public interface IReqDataManagement
    {
        int RaiseRequest_DAL(int reqId, int empId, string location_from, string location_to, approveS approveStatus, confirmB confirmBooking, currentS currentStatus);
        int EditRequest_DAL(TravelRequest travelRequest);
        int DeleteRequest_DAL(int reqId);
        int ApproveStatus_DAL(int reqId, approveS approve_status, currentS current_status);
        int ConfirmBooking_DAL(int reqId, confirmB confirm_booking, currentS current_status);
        int ViewAllRequest_DAL();
        int ViewJoinReqTable_DAL();
        int ViewNotApprovedRequests_DAL();
        int ViewPendingRequests_DAL();
        int ViewApprovedRequests_DAL();
        int ViewConfirmedRequests_DAL();
        int ViewOpenRequests_DAL();
        int ViewFromPerticularLocationRequests_DAL(string fromLocation);
        int ViewToPerticularLocationRequests_DAL(string locationto);
        TravelRequest GetReqByID_DAL(int reqId);
    }
}



















































































//////////////////////////////////////////////////////////
