using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class SystemConfigReadDto
    {
        public Guid ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string AppName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public byte[] AppLogo { get; set; }

        [Required]
        public byte[] HeroImage { get; set; }

    }
}