using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class RoomFeatureUpdateDto
    {
        [Required]
        public Guid RoomID { get; set; }

        [Required]
        public string Feature { get; set; }
    }
}