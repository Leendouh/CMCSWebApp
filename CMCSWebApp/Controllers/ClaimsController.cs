using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCSWebApp.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimsController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        public async Task<IActionResult> Index()
        {
            // bring table from the database / execute SQL
            IEnumerable<Claims> claims = await _claimRepository.GetAllClaimsAsync();

            // give you all the claims
            return View(claims);
        }
        public IActionResult Detail()
        {
            return View();
        }

    }
}
