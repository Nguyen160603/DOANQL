using DOANQL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using X.PagedList;

namespace DOANQL.Controllers
{
    public class BlogController : Controller
    {
        private readonly AlskContext _context;

        public BlogController(AlskContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            var Blogs = _context.TbBlogs.Where(i => (bool)i.IsActive).OrderByDescending(i => i.BlogId).ToPagedList((int)page, pageSize);
            ViewBag.blogComment = _context.TbBlogComments.ToList();
            return View(Blogs);
        }
        [Route("/Blog-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Blogs = _context.TbBlogs
                .FirstOrDefault(m => (m.BlogId == id) && (m.IsActive == true));
            if (Blogs == null)
            {
                return NotFound();
            }
            
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            return View(Blogs);
        }
        [HttpPost]
        public IActionResult Create(TbBlogComment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra tính hợp lệ của comment
                    if (string.IsNullOrWhiteSpace(comment.Name) || string.IsNullOrWhiteSpace(comment.Email) || string.IsNullOrWhiteSpace(comment.Detail))
                    {
                        ModelState.AddModelError(string.Empty, "Please provide a valid name, email, and comment.");
                        return RedirectToAction("Index"); // Chuyển hướng nếu có lỗi
                    }

                    // Kiểm tra và xử lý comment ở đây

                    // Thêm comment vào database
                    comment.CreatedDate = DateTime.Now;
                    _context.TbBlogComments.Add(comment);
                    _context.SaveChanges();

                    // Lấy danh sách comment cho view
                    var blogId = comment.BlogId; // Lấy ID của bài blog liên quan
                    ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == blogId).ToList();

                    // Load lại view Details để hiển thị comment
                    return PartialView("_CommentsPartial", ViewBag.blogComment);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần thiết
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return RedirectToAction("Index"); // Chuyển hướng đến trang chủ hoặc trang khác nếu cần thiết
        }


    }
}
