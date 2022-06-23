using DataAccess;
using Microsoft.EntityFrameworkCore;
using ItemModel = Item.DataAccess.Models.Item;

namespace Item.DataAccess
{
    public class ServiceContext : BaseContext
    {
        public ServiceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>(entity =>
              {
                  entity.HasKey(x => x.Id);
                  entity.Property(x => x.Id).ValueGeneratedOnAdd();
              }
            );
        }
    }
}
