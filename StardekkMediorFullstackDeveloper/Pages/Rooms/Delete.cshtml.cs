using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.Rooms
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            Room = unitOfWork.Rooms.GetById(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            Room = unitOfWork.Rooms.GetById(id);

            if (Room == null)
            {
                return NotFound();
            }

            unitOfWork.Rooms.Remove(Room);
            unitOfWork.Complete();

            return RedirectToPage("./Index");
        }
    }
}
