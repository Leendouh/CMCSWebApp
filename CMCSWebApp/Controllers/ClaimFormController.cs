using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using CMCSWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CMCSWebApp.Controllers
{
    public class ClaimFormController : Controller
    {

        private readonly IClaimFormRepository _claimFormRepository;

        public ClaimFormController(IClaimFormRepository claimFormRepository)
        {
            _claimFormRepository = claimFormRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
