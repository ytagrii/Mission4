using System;
using System.ComponentModel.DataAnnotations;
namespace Mission4.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Type a Valid Year")]
        public ushort Year { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }


        //forien key relationship with director
        [Required]
        public string Director { get; set; }
        //public Director Director { get; set; }

        //foreign key with category
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //foregn key for ratings
        [Required]
        public int RatingId { get; set; }
  
        public Rating Rating { get; set; }


    }
}
