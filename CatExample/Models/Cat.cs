using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatExample.Models
{
    public class Cat
    {
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        [Required]
        [Range(0, 15, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        
        [Required]
        public string Color { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime Birthdate { get; set; }
    }

    public enum Color
    {
        Black,
        Brown,
        White
    }
}
