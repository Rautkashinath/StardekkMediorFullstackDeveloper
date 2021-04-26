using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Repositories
{
    public class AmenityRepository : GenericRepository<Amenity>, IAmenityRepository
    {
        private StardekkDatabaseContext _databaseContext;

        public AmenityRepository(StardekkDatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        /// Method to demonostrates raw sql queries
        /// </summary>
        /// <returns>returns list of amenities</returns>
        public IEnumerable<Amenity> GetAmenities()
        {
            return _databaseContext.Amenities
                                   .FromSqlRaw("SELECT * FROM Amenities")
                                   .ToList();
        }

        /// <summary>
        /// no tracking query
        /// use this if you want to read only data
        /// any changes in this will not be tracked by SaveChanges 
        /// </summary>
        /// <returns>returns amenity</returns>
        public Amenity GetAmenityById(int id)
        {
            return _databaseContext.Amenities
                                   .FromSqlRaw("SELECT * FROM Amenities Where Id = {0}", id)
                                   .AsNoTracking()
                                   .FirstOrDefault();
        }
    }
}
