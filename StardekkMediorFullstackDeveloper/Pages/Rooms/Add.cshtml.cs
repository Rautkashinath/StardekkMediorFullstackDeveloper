using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.ViewModels;

namespace StardekkMediorFullstackDeveloper.Pages.Rooms
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork unitOfWork = new UnitOfWork();

                unitOfWork.Rooms.Add(Room);
                unitOfWork.Complete();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
