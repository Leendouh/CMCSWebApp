using CMCSWebApp.Models;

namespace CMCSWebApp.Interfaces
{
    public interface IReviewClaimsRepository
    {
        // get commands
        Task<IEnumerable<ReviewClaims>> GetAllClaimsAsync();
        Task<ReviewClaims> GetClaimsByIdAsync(int id);

        // CRUD's statements/commands
        bool Add(ReviewClaims cvClaims);
        bool Update(ReviewClaims cvClaims);
        bool Delete(ReviewClaims cvClaims);
        bool Save();
    }
}
