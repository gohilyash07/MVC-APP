using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class AddEmployeeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string? FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string? LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        [Range(1000000000, 9999999999, ErrorMessage = "Phone number should be 10 digits")]
        public string? Contact { get; set; }
    }
}
