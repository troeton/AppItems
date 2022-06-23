using BusinessLogic.LoginService;
using BusinessLogic.Models;
using Infraestructure.Common;
using Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CustomController
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }


        [HttpPost]
        public async Task<ActionResult<Response<string>>> Login(Request<UserLogin> user)
        {
            return Evaluate(await loginService.Login(user.Body));
        }

    }
}
