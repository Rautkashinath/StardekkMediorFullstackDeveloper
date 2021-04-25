using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.Rooms
{
    public class ListModel : PageModel
    {
        public List<Room> Room { get;set; }

        public void OnGet()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            Room = unitOfWork.Rooms.GetAll().ToList();
        }
    }
}
