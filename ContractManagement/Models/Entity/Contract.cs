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

        [Required]
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTimeCreated { get; protected set; }
        [Required]
        public string Institution { get; set; }
        [Required]
        public DateTime ClosingDate { get; set; }
        [Required]
        public DateTime ValidityDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
        

    }
}
