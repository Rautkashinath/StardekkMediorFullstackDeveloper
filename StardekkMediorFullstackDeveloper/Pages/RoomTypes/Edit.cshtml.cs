using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.RoomTypes
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RoomType RoomType { get; set; }

        public IActionResult OnGet(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            RoomType = unitOfWork.RoomTypes.GetById(id);

            if (RoomType == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork unitOfWork = new UnitOfWork();

                unitOfWork.RoomTypes.Update(RoomType);
                unitOfWork.Complete();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
