using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Dtos
{
    public class EmailReadDto
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid SystemConfigID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public bool Read { get; set; }

        public string DateSent { get; set; }

        public string DateReplied { get; set; }
    }
}