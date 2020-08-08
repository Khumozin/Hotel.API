using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class HotelFeature
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid SystemConfigID { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}