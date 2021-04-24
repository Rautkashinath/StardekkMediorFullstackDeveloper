using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.Repositories;

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
            UnitOfWork unitOfWork = new UnitOfWork();
            this.Amenities = unitOfWork.Amenities.GetAll().ToList();
        }
    }
}