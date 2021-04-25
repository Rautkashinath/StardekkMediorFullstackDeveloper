using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        public Room Room { get; set; }

        public IActionResult OnGet(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();

            Room = unitOfWork.Rooms.GetById(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
