using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StardekkDatabaseContext _databaseContext;
        
        public IAmenityRepository Amenities { get; private set; }

        public UnitOfWork()
        {
            _databaseContext = new StardekkDatabaseContext();
            Amenities = new AmenityRepository(_databaseContext);
        }

        public int Complete()
        {
            return _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}
