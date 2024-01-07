using DOANQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOANQL.Components
{
    [ViewComponent(Name = "RecentRoom")]
    public class RecentRoomViewComponent : ViewComponent
    {
        private readonly AlskContext _context;

        public RecentRoomViewComponent(AlskContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.TbRooms
                              where (p.IsActive == true)
                              orderby p.RoomId descending
                              select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }

    }
}
