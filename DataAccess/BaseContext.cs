using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BaseContext : DbContext
    {
        protected BaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}