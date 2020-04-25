using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Over18]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Dish> MyDishes {get;set;}
        public class Over18Attribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return new ValidationResult("Date of birth is required.");
                }
                else
                {
                    DateTime compare;
                    if (value is DateTime)
                    {
                        compare = (DateTime)value;
                        if (compare.AddYears(18) > DateTime.Now)
                        {
                            return new ValidationResult("You must be at least 18 years of age to register.");
                        }
                        else
                        {
                            return ValidationResult.Success;
                        }
                    }
                    else
                    {
                        return new ValidationResult("Not a valid date.");
                    }
                }
            }
        }
        public int Age(DateTime DateOfBirth)
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            return age;
        }
    }
}