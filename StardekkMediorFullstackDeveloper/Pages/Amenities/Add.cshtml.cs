using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardekkMediorFullstackDeveloper.Models;
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
                using (var db = new StardekkDatabaseContext())
                {
                    db.Add(new Amenity() {
                        Name = ViewModel.Name
                    });

                    await db.SaveChangesAsync();
                }

                return Redirect("/amenities/list");
            }

            // Modelstate wasn't valid
            return Page();
        }
    }
}