using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.RoomTypes
{
    public class AddModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoomType RoomType { get; set; }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork unitOfWork = new UnitOfWork();

                unitOfWork.RoomTypes.Add(RoomType);
                unitOfWork.Complete();

                return RedirectToPage("./Index");
            }
         
            return Page();
        }
    }
}
