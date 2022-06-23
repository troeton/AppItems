using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BaseContext _context;
        private readonly Dictionary<string, object> _repositories;

        public UnitOfWork(BaseContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }


        public IRepository<T> Repository<T>()
        where T : class
        {
            string name = typeof(T).Name;
            if (!_repositories.ContainsKey(name))
            {
                object? obj = Activator.CreateInstance(typeof(Repository<>).MakeGenericType(new Type[] { typeof(T) }), new object[] { _context });
#pragma warning disable CS8604 // Posible argumento de referencia nulo
                _repositories.Add(name, obj);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
            }
            return (Repository<T>)_repositories[name];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}