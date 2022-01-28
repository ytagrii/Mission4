using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public int RatingId { get; set; }

        [Required]
        public string rateName { get; set; }
    }
}
