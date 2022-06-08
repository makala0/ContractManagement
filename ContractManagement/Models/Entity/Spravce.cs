using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.Models.Entity
{
    [Table(nameof(Spravce))]
    public class Spravce
    {
        [Required]
        [Key]
        public int SpravceId { get; set; }
        [Required(ErrorMessage = "Musíte vyplnit jméno.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Jméno musí mít velikost mezi 3 až 30 znaky.")]
        public string Jmeno { get; set; }

        [Required(ErrorMessage = "Musíte vyplnit příjmení.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Příjmení musí mít velikost mezi 3 až 30 znaky.")]
        public string Prijmeni { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Zadejte validní emailovou adresu.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Zadejte validní rodné číslo.")]
        [DisplayFormat(DataFormatString = "{0;######/####")]
        public string RodneCislo { get; set; }

        [Required]
        [Range(18, 99, ErrorMessage = "Věk musí být mezi 18 až 99.")]
        public int Vek { get; set; }

    }
}
