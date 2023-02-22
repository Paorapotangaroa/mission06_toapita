using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_toapita.Models
{
    //Define a movies model with the stuff from the spreadsheet
    public class Movies
    {
        //Primary key and required
        [Key]
        [Required]
        public int MovieID { get; set; }

        //Require some every field except Edited, Lent To, and Notes
        //FK relationship setup
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent_To { get; set; }

        //Limit notes to 25 Characters
        [MaxLength(25)]
        public string Notes { get; set; }

        //Create a static variable so I can use it to dynamically create options
        // Because I'm lazy and hate typing more than I have to
        public static string[] RatingOptions = { "G", "PG", "PG-13", "R" };
    }
}
