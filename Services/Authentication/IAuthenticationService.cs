using DataAccess.Entities;
using System.Threading.Tasks;

namespace Service.Authentication
{
   
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
        bool VerifySignedJwt(string token);
        User IsAuthenticated(string email, string password);
        int GetUserId();
        Task<bool> IsActive(string token);
        Task<bool> IsCurrentActiveToken();
    }

}
