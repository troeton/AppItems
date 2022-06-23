using DataAccess.UnitOfWork;
using Login.DataAccess.Models;

namespace Login.Service
{
    public static class InitializeDatabaseManager
    {
        public static WebApplication InitializeDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                unitOfWork.Repository<User>().Insert(
                new() { Id = 1, Email = "example@example.com", Password = "12345", Name = "Usuario 1" }
                );
                unitOfWork.Save();
            }
            return webApp;
        }
    }
}
