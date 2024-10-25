using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using CMCSWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CMCSWebApp.Controllers
{
    public class SubmittedClaimsController : Controller
    {
        private readonly ISubmittedClaimsRepository _submittedClaimsRepository;

        public SubmittedClaimsController(ISubmittedClaimsRepository submittedClaimsRepository)
        {
            _submittedClaimsRepository = submittedClaimsRepository;
        }
        public async Task<IActionResult> Index()
        {
            // bring table from the database / execute SQL
            IEnumerable<SubmittedClaims> sbClaims = await _submittedClaimsRepository.GetAllClaimsAsync();

            // give you all the claims
            return View(sbClaims);
        }


        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Claims()
        {
            return View();
        }

    }
}