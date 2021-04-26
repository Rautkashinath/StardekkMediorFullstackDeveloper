using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper
{
    public class ListModel : PageModel
    {
        public List<Amenity> Amenities { get; set; }

        public void OnGetAsync()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            Amenities = unitOfWork.Amenities.GetAmenities().ToList();
        }
    }
}