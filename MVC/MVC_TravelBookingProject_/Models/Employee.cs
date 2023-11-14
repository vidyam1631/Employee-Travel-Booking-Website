using System;
using System.Collections.Generic;

namespace MVC_TravelBookingProject_.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TravelRequests = new HashSet<TravelRequest>();
        }

        public int EmpId { get; set; }
        public string EmpFname { get; set; } = null!;
        public string? EmpLname { get; set; }
        public DateTime? EmpDob { get; set; }
        public string? EmpAddress { get; set; }
        public string? EmpContact { get; set; }

        public virtual ICollection<TravelRequest> TravelRequests { get; set; }
    }
}
