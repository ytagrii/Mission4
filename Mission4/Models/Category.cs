using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string cName { get; set; }
    }
}
