using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper
{
    public class ListModel : PageModel
    {
        public List<Amenity> Amenities { get; set; }

        public async Task OnGetAsync()
        {
            await InitAsync();
        }

        private async Task InitAsync()
        {
            using(var db = new StardekkDatabaseContext())
            {
                this.Amenities = await db.Amanities.ToListAsync();
            }
        }
    }
}