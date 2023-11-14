using MVC_TravelBookingProject_.Models;

namespace MVC_TravelBookingProject_.Repository
{
    public interface ITravelRequestRepository
    {
        IEnumerable<TravelRequest> GetAllRequests();
        void AddTravelRequest(TravelRequest e);
        void DeleteTravelRequest(int id);
        TravelRequest GetTravelRequestByid(int id);
        void UpdateTravelRequest(int id, TravelRequest e);
        void ApproveTravelRequest(int id, string status);

        void BookTravelRequest(int id, string status);
    }
}
