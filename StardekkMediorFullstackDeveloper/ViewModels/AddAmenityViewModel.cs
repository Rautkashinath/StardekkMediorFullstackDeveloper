using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StardekkMediorFullstackDeveloper.ViewModels
{
    public class AddAmenityViewModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
