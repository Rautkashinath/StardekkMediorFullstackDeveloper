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

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork unitOfWork = new UnitOfWork();

                unitOfWork.Rooms.Update(Room);
                unitOfWork.Complete();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
