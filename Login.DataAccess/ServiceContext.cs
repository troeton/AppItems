using DataAccess;
using Login.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.DataAccess
{
    public class ServiceContext : BaseContext
    {
        public ServiceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
               {
                   entity.HasKey(x => x.Id);
                   entity.Property(x => x.Id).ValueGeneratedOnAdd();
               }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "exmaple@example.com", Password = "12345", Name = "Usurio 1" }
                );

        }

    }
}