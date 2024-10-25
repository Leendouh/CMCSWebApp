using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CMCSWebApp.Repository
{
    public class ClaimFormRepository : IClaimFormRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ClaimForm claimF)
        {
            _context.Add(claimF);
            // sending data into database
            return Save();
        }

        public bool Delete(ClaimForm claimF)
        {
            _context.Remove(claimF);
            // sending data into database
            return Save();
        }

        public async Task<IEnumerable<ClaimForm>> GetAllClaimsAsync()
        {
            return await _context.ClaimForms.ToListAsync();
        }

        public async Task<ClaimForm> GetClaimsByIdAsync(int id)
        {
            return await _context.ClaimForms.FirstOrDefaultAsync(i => i.ClaimID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ClaimForm claimF)
        {
            _context.Update(claimF);
            return Save();
        }
    }
}