using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class RoomReadDto
    {
        public Guid ID { get; set; }

        [Required]
        public Guid SystemConfigID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public byte[] Thumbnail { get; set; }
    }
}