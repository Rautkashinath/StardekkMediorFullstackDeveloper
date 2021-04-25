using System;

namespace StardekkMediorFullstackDeveloper.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAmenityRepository Amenities { get; }
        
        IRoomRepository Rooms { get;  }

        IRoomTypeRepository RoomTypes { get;  }

        void Complete();
    }
}
