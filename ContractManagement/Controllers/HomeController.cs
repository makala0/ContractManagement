using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models;
using ContractManagement.Models.Database;
using ContractManagement.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using ContractManagement.Models.Identity;
using ContractManagement.Models.ApplicationServices.Abstraction;
using ContractManagement.Models.Entity;

namespace ContractManagement.Controllers
{
    public class HomeController : Controller
    {
        readonly contractDbContext _context;
        ISecurityApplicationService iSecure;

        public HomeController(contractDbContext context, ISecurityApplicationService iSecure)
        {
            _context = context;
            this.iSecure = iSecure;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>Welcome()
        {
            User currentUser = await iSecure.GetCurrentUser(User);
            if (currentUser != null)
            {
                
                return View(currentUser);
            }
            return NotFound();   
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
