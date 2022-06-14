using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.Identity;

namespace ContractManagement.Models.Entity
{
    [Table(nameof(Contract))]
    public class Contract
    {

        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int RegistrationNumber { get; set; }

        [ForeignKey("Institution")]
        public int InstitutionID { get; set; }
        public Institution Institution { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTimeCreated { get; protected set; }

        [Required]
        public DateTime ClosedDate  { get; set; } // datum uzavreni

        [Required]
        public DateTime ValidityDate { get; set; } // datum platnosti

        [Required]
        public DateTime EndDate { get; set; }  // datum ukonceni

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
