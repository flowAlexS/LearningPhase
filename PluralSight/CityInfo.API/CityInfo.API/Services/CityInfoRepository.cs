using CityInfo.API.DbContext;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<City>> GetCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City?> GetCityAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<PointOfInterest?> GetPointOfInterestForACityAsync(
            int cityId,
            int pointOfInterestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForACityAsync(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
