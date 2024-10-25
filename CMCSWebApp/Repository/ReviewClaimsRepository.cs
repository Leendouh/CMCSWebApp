using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CMCSWebApp.Repository
{
    public class ReviewClaimsRepository : IReviewClaimsRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewClaimsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ReviewClaims cvClaims)
        {
            _context.Add(cvClaims);
            // sending data into database
            return Save();
        }

        public bool Delete(ReviewClaims cvClaims)
        {
            _context.Remove(cvClaims);
            // sending data into database
            return Save();
        }

        public async Task<IEnumerable<ReviewClaims>> GetAllClaimsAsync()
        {
            return await _context.ReviewClaims.ToListAsync();
        }

        public async Task<ReviewClaims> GetClaimsByIdAsync(int id)
        {
            return await _context.ReviewClaims.FirstOrDefaultAsync(i => i.ClaimID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ReviewClaims cvClaims)
        {
            _context.Update(cvClaims);
            return Save();
        }
    }
}
