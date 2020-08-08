using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Dtos
{
    public class HotelFeatureCreateDto
    {
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