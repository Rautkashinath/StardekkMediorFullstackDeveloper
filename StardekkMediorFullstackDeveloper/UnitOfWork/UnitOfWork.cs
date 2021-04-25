using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.Repositories;

namespace StardekkMediorFullstackDeveloper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StardekkDatabaseContext _databaseContext;
        
        public IAmenityRepository Amenities { get; private set; }

        public IRoomRepository Rooms { get; private set; }

        public IRoomTypeRepository RoomTypes { get; private set; }

        public UnitOfWork()
        {
            _databaseContext = new StardekkDatabaseContext();
            Amenities = new AmenityRepository(_databaseContext);
            Rooms = new RoomRepository(_databaseContext);
            RoomTypes = new RoomTypeRepository(_databaseContext);
        }

        public void Complete()
        {
            _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}
