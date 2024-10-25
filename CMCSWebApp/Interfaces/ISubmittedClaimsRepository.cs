using CMCSWebApp.Models;

namespace CMCSWebApp.Interfaces
{
    public interface ISubmittedClaimsRepository
    {
        // get commands
        Task<IEnumerable<SubmittedClaims>> GetAllClaimsAsync();
        Task<SubmittedClaims> GetClaimsByIdAsync(int id);

        // CRUD's statements/commands
        bool Add(SubmittedClaims sbClaims);
        bool Update(SubmittedClaims sbClaims);
        bool Delete(SubmittedClaims sbClaims);
        bool Save();
    }
}
