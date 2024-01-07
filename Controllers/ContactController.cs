using DOANQL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace DOANQL.Controllers
{
    public class ContactController : Controller
    {
        public readonly AlskContext _context;
        public ContactController(AlskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string email, string subject, string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Email = email;
                contact.Subject = subject;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
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
