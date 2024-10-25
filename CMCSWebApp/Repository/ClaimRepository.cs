using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CMCSWebApp.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Claims claims)
        {
            _context.Add(claims);
            // sending data into database
            return Save();
        }

        public bool Delete(Claims claims)
        {
            _context.Remove(claims);
            // sending data into database
            return Save();
        }

        public async Task<IEnumerable<Claims>> GetAllClaimsAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claims> GetClaimsByIdAsync(int id)
        {
            return await _context.Claims.FirstOrDefaultAsync(i => i.ClaimsID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Claims claims)
        {
            _context.Update(claims);
            return Save();
        }
    }
}
