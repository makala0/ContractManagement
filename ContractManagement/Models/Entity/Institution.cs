using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.Models.Entity
{
    [Table("Institution")]
    public class Institution
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [Display(Name="Name of institution")]
        public string Name { get; set; }
        [ForeignKey("Administrator")]
        public int ConsultantID { get; set; }
        public Consultant Consultant { get; set; }
    }
}
