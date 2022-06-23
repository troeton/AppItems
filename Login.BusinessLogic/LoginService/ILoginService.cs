using BusinessLogic.Models;
using Infraestructure.Models;

namespace BusinessLogic.LoginService
{
    public interface ILoginService
    {
        Task<Response<string>> Login(UserLogin userLogin);
    }
}
