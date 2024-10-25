using CMCSWebApp.Models;
using System.Security.Claims;

namespace CMCSWebApp.Interfaces
{
    public interface IClaimRepository
    {
        // get commands
        Task<IEnumerable<Claims>> GetAllClaimsAsync();
        Task<Claims> GetClaimsByIdAsync(int id);

        // CRUD's statements/commands
        bool Add(Claims claims);
        bool Update(Claims claims);
        bool Delete(Claims claims);
        bool Save();
    }
}
