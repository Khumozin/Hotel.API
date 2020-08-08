using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class RoomFeature
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid RoomID { get; set; }

        [Required]
        public string Feature { get; set; }
    }
}