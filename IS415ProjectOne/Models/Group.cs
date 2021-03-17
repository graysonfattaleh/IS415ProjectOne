using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models
{
    public class Group
    {
        [Key]
        [Required]
        public int GroupId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string GroupName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Size { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")] 
        public string Email { get; set; }

        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public DateTime StartTime { get; set; }
    }
}
