using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetVet.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Pet Name can only be 50 characters long")]
        public string PetName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Owner's Name can only be 50 characters long")]
        public string OwnersName { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "Contact Detail can only be 13 characters long")]
        public string ContactDetail { get; set; }
    }
}
