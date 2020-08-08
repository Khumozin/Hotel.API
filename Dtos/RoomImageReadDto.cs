using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class RoomImageReadDto
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid RoomID { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}