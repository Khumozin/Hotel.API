using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class RoomImageCreateDto
    {
        [Required]
        public Guid RoomID { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}