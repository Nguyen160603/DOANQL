using DOANQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DOANQL.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly AlskContext _context;

        public BlogController(AlskContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var AlskContext = _context.TbBlogs.Include(t => t.Account).Include(t => t.Category);
            return View(await AlskContext.ToListAsync());
        }
    }
}
