using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Pages.Amenities
{
    public class DetailsModel : PageModel
    {
        public Amenity Amenity { get; set; }

        public IActionResult OnGet(int id)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            Amenity = unitOfWork.Amenities.GetAmenityById(id);

            if (Amenity == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
