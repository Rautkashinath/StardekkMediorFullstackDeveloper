using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.ViewModels;

namespace StardekkMediorFullstackDeveloper.Pages.Rooms
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public AddRoomViewModel RoomViewModel { get; set; }

        public IActionResult OnGet(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            
            Room room = unitOfWork.Rooms.GetById(id);
            
            if (room == null)
            {
                return NotFound();
            }

            RoomViewModel = RoomViewModel ?? new AddRoomViewModel();

            RoomViewModel.Id = room.Id;
            RoomViewModel.Name = room.Name;
            RoomViewModel.CreationDate = room.CreationDate.DateTime;
            RoomViewModel.RoomNumber = room.RoomNumber;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork unitOfWork = new UnitOfWork();

                var room = new Room
                {
                    Id = RoomViewModel.Id,
                    CreationDate = RoomViewModel.CreationDate,
                    RoomNumber = RoomViewModel.RoomNumber,
                    Name = RoomViewModel.Name
                };

                unitOfWork.Rooms.Update(room);
                unitOfWork.Complete();

                return RedirectToPage("./List");
            }

            return Page();
        }
    }
}
