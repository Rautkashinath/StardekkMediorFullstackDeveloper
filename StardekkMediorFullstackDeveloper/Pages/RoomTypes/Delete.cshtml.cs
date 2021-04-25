using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.RoomTypes
{
    public class DeleteModel : PageModel
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

        public IActionResult OnPost(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            RoomType = unitOfWork.RoomTypes.GetById(id);

            if (RoomType != null)
            {
                unitOfWork.RoomTypes.Remove(RoomType);
                unitOfWork.Complete();
            }

            return RedirectToPage("./Index");
        }
    }
}
