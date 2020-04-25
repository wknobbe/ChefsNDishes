using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters long.")]
        public string Name {get;set;}
        [Required]
        [Range(0,9999)]
        public int Calories {get;set;}
        [Required]
        [Range(1,6)]
        public int Tastiness {get;set;}
        [Required]
        [MinLength(4, ErrorMessage="Description must be at least 4 characters.")]
        public string Description {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        [Required]
        public int ChefId {get;set;}
        public Chef Cook {get;set;}
    }
}