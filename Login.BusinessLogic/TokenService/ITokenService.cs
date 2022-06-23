using Infraestructure.Models;
using Login.BusinessLogic.Models;

namespace BusinessLogic.TokenService
{
    public interface ITokenService
    {
        Response<string> GenerateToken(User user);
    }
}
