using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.Repositories;
using StardekkMediorFullstackDeveloper.ViewModels;

namespace StardekkMediorFullstackDeveloper
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddAmenityViewModel ViewModel { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                // Store the entered amenity in our local database
                UnitOfWork unitOfWork = new UnitOfWork();
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