using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CMCSWebApp.Repository
{
    public class SubmittedClaimsRepository : ISubmittedClaimsRepository
    {
        private readonly ApplicationDbContext _context;

        public SubmittedClaimsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(SubmittedClaims sbClaims)
        {
            _context.Add(sbClaims);
            // sending data into database
            return Save();
        }

        public bool Delete(SubmittedClaims sbClaims)
        {
            _context.Remove(sbClaims);
            // sending data into database
            return Save();
        }

        public async Task<IEnumerable<SubmittedClaims>> GetAllClaimsAsync()
        {
            return await _context.SubmittedClaims.ToListAsync();
        }

        public async Task<SubmittedClaims> GetClaimsByIdAsync(int id)
        {
            return await _context.SubmittedClaims.FirstOrDefaultAsync(i => i.ClaimID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(SubmittedClaims sbClaims)
        {
            _context.Update(sbClaims);
            return Save();
        }
    }
}
