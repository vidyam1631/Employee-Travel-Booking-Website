using ClassLibrary_ProjectMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_BusinessAccessLayer
{
    public interface ITravelRequestBAL
    {
        int RaiseRequest_BAL(int reqId, int empId, string location_from, string location_to, approveS approveStatus, confirmB confirmBooking, currentS currentStatus);
        int EditRequest_BAL(TravelRequest travelRequest);
        int DeleteRequest_BAL(int reqId);
        int ApproveStatus_BAL(int reqId, approveS approve_status, currentS current_status);
        int ConfirmBooking_BAL(int reqId, confirmB confirm_booking, currentS current_status);
        void ViewAllRequest_BAL();
        int ViewJoinReqTable_BAL();
        int ViewApprovedRequests_BAL();
        int ViewPendingRequests_BAL();

        int ViewFromPerticularLocationRequests_BAL(string fromLocation);
        int ViewToPerticularLocationRequests_BAL(string locationto);
        int ViewNotApprovedRequests_BAL();
        int ViewConfirmedRequests_BAL();
        int ViewOpenRequests_BAL();
        TravelRequest GetReqByID_BAL(int reqId);
    }
}
