using System.ComponentModel.DataAnnotations;

namespace StardekkMediorFullstackDeveloper.ViewModels
{
    public class AddAmenityViewModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
