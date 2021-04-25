using System;
using System.ComponentModel.DataAnnotations;

namespace StardekkMediorFullstackDeveloper.ViewModels
{
    public class AddRoomViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public string RoomNumber { get; set; }
    }
}
