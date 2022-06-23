using AutoMapper;
using BusinessLogic.Models;
using BusinessLogic.TokenService;
using DataAccess.UnitOfWork;
using Infraestructure.Models;
using Login.BusinessLogic.Models;
using Microsoft.Extensions.Logging;
using UserDAO = Login.DataAccess.Models.User;

namespace BusinessLogic.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<LoginService> logger;

        public LoginService(ITokenService tokenService, IUnitOfWork unitOfWork, IMapper mapper, ILogger<LoginService> logger)
        {
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Response<string>> Login(UserLogin userLogin)
        {
            try
            {
                var user = mapper.Map<User>((await unitOfWork.Repository<UserDAO>().GetAsync(x =>
                    x.Email.Equals(userLogin.UserName) && x.Password.Equals(userLogin.Password))).FirstOrDefault());
                if (user == null)
                    return new() { Errors = new List<string>() { "Credenciales incorrectas" } };
                return tokenService.GenerateToken(user);
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
                return new() { Errors = new List<string>() { "ha ocurrido un error inesperado" } };
            }
        }
    }
}
