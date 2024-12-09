using System.ComponentModel.DataAnnotations;

namespace CRUD_ALL.Models
{
    public class Employee_Model
    {
        public int Emp_ID { get; set; }

        [Required(ErrorMessage ="Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Address")]

        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password",ErrorMessage ="Password Not Match")]
        public string? Confirm_Password { get; set; }
    }
}
