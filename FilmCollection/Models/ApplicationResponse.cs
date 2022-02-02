using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

 
namespace FilmCollection.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter the Year of the movie")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required(ErrorMessage = "the rating is required!")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LenTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

        //Build the foreign key relationship
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
