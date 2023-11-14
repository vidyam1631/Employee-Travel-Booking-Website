using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_TravelBookingProject_.Models;

namespace MVC_TravelBookingProject_.Repository
{
    public class TravelRequestRepository: ITravelRequestRepository
    {
        private readonly TicketBooking_DbContext _ticketbooking;
        public TravelRequestRepository(TicketBooking_DbContext ticketbooking)
        {
            _ticketbooking = ticketbooking;
        }
        public IEnumerable<TravelRequest> GetAllRequests()
        {
            IEnumerable<TravelRequest> tr = _ticketbooking.TravelRequests.Include(x => x.Emp);
            return tr;
            //return _ticketbooking.TravelRequests;
        }
        public void AddTravelRequest(TravelRequest request)
        {
            if (request != null)
            {
                request.ApprovalStatus = "Pending";
                request.CurrentStatus = "Open";
                request.BookingStatus = "Pending";
                _ticketbooking.Add(request);
                _ticketbooking.SaveChanges();
            }

        }
        public void DeleteTravelRequest(int id)
        {
            TravelRequest t = _ticketbooking.TravelRequests.FirstOrDefault(x => x.RequestId == id);
            if (t != null)
            {
                _ticketbooking.TravelRequests.Remove(t);
                _ticketbooking.SaveChanges();
            }
        }
        public TravelRequest GetTravelRequestByid(int id)
        {
            TravelRequest t = _ticketbooking.TravelRequests.FirstOrDefault(x => x.RequestId == id);
            return t;

        }
        public void UpdateTravelRequest(int id, TravelRequest t)
        {
            TravelRequest old_req = _ticketbooking.TravelRequests.FirstOrDefault(x => x.RequestId == id);
            if (old_req != null)
            {
                //ViewBag.Employees = new SelectList(_repository.GetEmployees(), "EmpId", "EmpFirstName")
                old_req.LocationFrom = t.LocationFrom;
                old_req.LocationTo = t.LocationTo;
                //old_req.ApprovalStatus = t.ApprovalStatus;
                //old_req.BookingStatus = t.BookingStatus;
                _ticketbooking.SaveChanges(true);
            }

        }
        public void ApproveTravelRequest(int id, string status)
        {
            TravelRequest tr = _ticketbooking.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (tr != null)
            {
                tr.ApprovalStatus = status;
                if (tr.ApprovalStatus == "NotApproved")
                {
                    tr.CurrentStatus = "Close";
                }
                _ticketbooking.SaveChanges();
            }
        }

        public void BookTravelRequest(int id, string status)
        {

            TravelRequest tr = _ticketbooking.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (tr != null)
            {

                tr.BookingStatus = status;
                tr.CurrentStatus = "Close";
                _ticketbooking.SaveChanges(true);

            }


        }
    }
}
