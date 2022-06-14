﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.Models.Identity
{
    public class User : IdentityUser<int>
    {
        [Required(ErrorMessage = "Fill the firstname")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Firstname - Length of min. 3 and max of 30 characters.")]
        [Display(Name = "Consultant's name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill the lastname.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Lastname - Length of min. 3 and max of 30 characters.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required]

        public string BirthNumber { get; set; }

        [Required]
        [Range(18, 99, ErrorMessage = "Enter age between 18-99.")]
        public int Age { get; set; }
    }
}
