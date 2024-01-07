using DOANQL.Models;
using Microsoft.AspNetCore.Mvc;


namespace DOANQL.Controllers
{
    public class BookingController : Controller
    {
        public readonly AlskContext _context;
        public BookingController(AlskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string email,int adults,int children,DateTime arivaldate, DateTime departuredate ,string message)
        {
            try
            {
                TbBooking booking = new TbBooking();
                booking.Name = name;
                booking.Email = email;
                booking.Message = message;
                booking.ArivalDate = arivaldate;
                booking.DepartureDate = departuredate;
                booking.Adults = adults;
                booking.Children = children;
                booking.CreatedDate = DateTime.Now;
                _context.Add(booking);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

    }

}

