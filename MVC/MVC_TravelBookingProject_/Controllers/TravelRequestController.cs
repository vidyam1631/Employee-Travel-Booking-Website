using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_TravelBookingProject_.Models;
using MVC_TravelBookingProject_.Repository;
using System.Collections.Generic;

namespace MVC_TravelBookingProject_.Controllers
{
    public class TravelRequestController : Controller
    {
        private readonly ITravelRequestRepository _tR;
        private readonly IEmployeeRepository _emR;
        public TravelRequestController(ITravelRequestRepository tR, IEmployeeRepository emR)
        {
            _tR = tR;
            _emR = emR;
        }
        public IActionResult Index()
        {
            IEnumerable<TravelRequest> requests = _tR.GetAllRequests();
            return View(requests);
        }
        public IActionResult AddTravelRequest()
        {
            ViewBag.Employees = new SelectList(_emR.GetAllEmployees(), "EmpId","EmpFname" );
            return View();
        }
        [HttpPost]
        public IActionResult AddTravelRequest(TravelRequest t)
        {

            if (ModelState.IsValid)
            {
                //Console.WriteLine("In Add  product" + p.Name);
                _tR.AddTravelRequest(t);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTravelRequest(int id)
        {
            if (id != null)
            {
                _tR.DeleteTravelRequest(id);
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateTravelRequest(int id)
        {

            TravelRequest t = _tR.GetTravelRequestByid(id);
            ViewBag.Employees = new SelectList(_emR.GetAllEmployees(), "EmpId", "EmpFname");
            return View(t);
        }
        [HttpPost]
        public IActionResult UpdateTravelRequest(int id, TravelRequest t)
        {
            if (ModelState.IsValid)
            {
                _tR.UpdateTravelRequest(id, t);
            }
            return RedirectToAction("Index");

        }
        public IActionResult ApproveTravelRequest(int id)
        {
            ViewBag.Employees = new SelectList(_emR.GetAllEmployees(), "EmpId", "EmpFname");
            TravelRequest tr = _tR.GetTravelRequestByid(id);
            return View(tr);
        }

        [HttpPost]
        public IActionResult ApproveTravelRequest(int id, string ApproveStatus)
        {
            if (ModelState.IsValid)
            {
                _tR.ApproveTravelRequest(id, ApproveStatus);
            }
            return RedirectToAction("Index");
        }

        public IActionResult BookTravelRequest(int id)
        {
            ViewBag.Employees = new SelectList(_emR.GetAllEmployees(), "EmpId", "EmpFname");
           
            TravelRequest tr = _tR.GetTravelRequestByid(id);
            return View(tr);
        }

        [HttpPost]
        public IActionResult BookTravelRequest(int id, string BookingStatus )
        {
            if (ModelState.IsValid)
            {
                _tR.BookTravelRequest(id, BookingStatus);
            }
            return RedirectToAction("Index");
        }
    }
}
