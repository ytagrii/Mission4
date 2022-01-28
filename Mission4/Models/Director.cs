using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class Director
    {
        [Key]
        [Required]
        public int DirectorId { get; set; }

        [Required]
        public string dFirstName { get; set; }

        [Required]
        public string dLastName { get; set; }
    }
}
