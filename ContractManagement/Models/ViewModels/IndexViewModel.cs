using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.Entity;

namespace ContractManagement.Models.ViewModels
{
    public class IndexViewModel
    {
        public IList<Spravce> Products { get; set; }
    }
}
