using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class SystemConfig
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string AppName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public byte[] AppLogo { get; set; }

        [Required]
        public byte[] HeroImage { get; set; }

    }
}