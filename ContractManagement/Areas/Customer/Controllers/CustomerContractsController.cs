using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.ApplicationServices.Abstraction;
using ContractManagement.Models.Database;
using ContractManagement.Models.Entity;
using ContractManagement.Models.Identity;

namespace ContractManagement.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerContractsController : Controller
    {

        ISecurityApplicationService iSecure;
        contractDbContext contractDbContext;

        public CustomerContractsController(ISecurityApplicationService iSecure, contractDbContext contractDBContext)
        {
            this.iSecure = iSecure;
            this.contractDbContext = contractDBContext;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                User currentUser = await iSecure.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<Contract> userContracts = await this.contractDbContext.Contracts
                                                                        .Where(or => or.UserId == currentUser.Id)
                                                                        .Include(o => o.User)
                                                                        .Include(o => o.Institution)
                                                                        .ThenInclude(o => o.Consultant)
                                                                        .ToListAsync();
                    return View(userContracts);
                }
            }

            return NotFound();
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await contractDbContext.Consultants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }
    }
}
