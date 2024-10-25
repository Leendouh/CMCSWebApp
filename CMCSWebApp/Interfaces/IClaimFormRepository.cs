using CMCSWebApp.Models;

namespace CMCSWebApp.Interfaces
{
    public interface IClaimFormRepository
    {
        // get commands
        Task<IEnumerable<ClaimForm>> GetAllClaimsAsync();
        Task<ClaimForm> GetClaimsByIdAsync(int id);

        // CRUD's statements/commands
        bool Add(ClaimForm claimF);
        bool Update(ClaimForm claimF);
        bool Delete(ClaimForm claimF);
        bool Save();
    }
}
