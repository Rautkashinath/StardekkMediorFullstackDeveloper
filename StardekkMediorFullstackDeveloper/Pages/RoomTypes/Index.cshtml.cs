using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.RoomTypes
{
    public class IndexModel : PageModel
    {
        //// Containes list of room type
        public IList<RoomType> RoomType { get;set; }

        public void OnGetAsync()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            RoomType = unitOfWork.RoomTypes.GetAll().ToList();
        }
    }
}
