using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_toapita.Models
{
    //Define the category class with both primary key and description
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
    }
}
