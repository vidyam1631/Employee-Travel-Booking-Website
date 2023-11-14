using System;
using System.Collections.Generic;

namespace MVC_TravelBookingProject_.Models
{
    public partial class TravelRequest
    {
        public int RequestId { get; set; }
        public int? EmpId { get; set; }
        public string? LocationFrom { get; set; }
        public string? LocationTo { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? BookingStatus { get; set; }
        public string? CurrentStatus { get; set; }

        public virtual Employee? Emp { get; set; }
    }
}
