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
        public AddRoomViewModel RoomViewModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork _unitOfWork = new UnitOfWork();

                var room = new Room
                {
                   CreationDate = RoomViewModel.CreationDate,
                   RoomNumber = RoomViewModel.RoomNumber,
                   Name = RoomViewModel.Name
                };

                _unitOfWork.Rooms.Add(room);
                _unitOfWork.Complete();

                return RedirectToPage("./List");
            }

            return Page();
        }
    }
}
