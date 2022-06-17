using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [StringLength(11,ErrorMessage = "BirthNumber can have maximum of 11 characters")]
        public string BirthNumber { get; set; }

        [Range(18, 99, ErrorMessage = "Enter age between 18-99.")]
        [Required]
        public int Age { get; set; }


        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{4,}$", ErrorMessage = RegisterViewModel.ErrorMessagePassword)]
        public string Password { get; set; }
        private const string ErrorMessagePassword = "Passwords must be at least 4 characters.<BR>Passwords must have at least one non alphanumeric character.<BR>Passwords must have at least one digit('0'-'9').<BR>Passwords must have at least one uppercase('A'-'Z').";

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
        public string RepeatedPassword { get; set; }
    }
}
