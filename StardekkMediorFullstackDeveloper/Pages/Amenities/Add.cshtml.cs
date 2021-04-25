using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.ViewModels;

namespace StardekkMediorFullstackDeveloper
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddAmenityViewModel ViewModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                // Store the entered amenity in our local database
                IUnitOfWork unitOfWork = new UnitOfWork();

                unitOfWork.Amenities.Add(new Amenity()
                                        {
                                            Name = ViewModel.Name
                                        });
                unitOfWork.Complete();

                return Redirect("/amenities/list");
            }

            // Modelstate wasn't valid
            return Page();
        }
    }
}