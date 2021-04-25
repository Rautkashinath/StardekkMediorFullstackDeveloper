﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            this.Amenities = unitOfWork.Amenities.GetAll().ToList();
        }
    }
}