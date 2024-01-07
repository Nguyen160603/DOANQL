using DOANQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOANQL.Components
{
    [ViewComponent(Name = "Category")]
    public class CategoryComponent : ViewComponent
    {
        private readonly AlskContext _context;

        public CategoryComponent(AlskContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = _context.TbCategorys.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();


            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }

    }
}
