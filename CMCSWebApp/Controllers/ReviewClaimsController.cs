using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using CMCSWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMCSWebApp.Controllers
{
    public class ReviewClaimsController : Controller
    {
        private readonly IReviewClaimsRepository _reviewClaimsRepository;

        public ReviewClaimsController(IReviewClaimsRepository reviewClaimsRepository)
        {
            _reviewClaimsRepository = reviewClaimsRepository;
        }
        public async Task<IActionResult> Index()
        {
            // bring table from the database / execute SQL
            IEnumerable<ReviewClaims> rvClaims = await _reviewClaimsRepository.GetAllClaimsAsync();

            // give you all the claims
            return View(rvClaims);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
