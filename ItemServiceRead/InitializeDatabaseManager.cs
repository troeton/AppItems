using DataAccess.UnitOfWork;
using ItemDAO = Item.DataAccess.Models.Item;

namespace ItemServiceRead
{
    public static class InitializeDatabaseManager
    {
        public static WebApplication InitializeDatabase(this WebApplication webApp)
        {
            Random random = new();
            using (var scope = webApp.Services.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                for (int i = 1; i <= 100; i++)
                    unitOfWork.Repository<ItemDAO>().Insert(
                    new() { Id = i, Description = $"Item {i}", Stock = random.Next(1, 1000) }
                    );
                unitOfWork.Save();
            }
            return webApp;
        }
    }
}
