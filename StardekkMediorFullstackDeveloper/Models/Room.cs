using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StardekkMediorFullstackDeveloper.Models
{
    public class Room
    {
        public int Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
    }
}
