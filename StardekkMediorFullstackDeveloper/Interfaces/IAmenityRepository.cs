using System.Collections.Generic;
using StardekkMediorFullstackDeveloper.Models;
using StardekkMediorFullstackDeveloper.Repositories;

namespace StardekkMediorFullstackDeveloper.Interfaces
{
    public interface IAmenityRepository : IGenericRepository<Amenity>
    {
        /// <summary>
        /// Method to demonostrates raw sql queries
        /// </summary>
        /// <returns></returns>
        IEnumerable<Amenity> GetAmenities();

        /// <summary>
        /// demonstrates No tracking query
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Amenity GetAmenityById(int id);
    }
}
