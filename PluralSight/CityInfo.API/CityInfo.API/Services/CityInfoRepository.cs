using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        public Task<IEnumerable<City>> GetCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City?> GetCityAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<PointOfInterest?> GetPointOfInterestForACity(int cityId, int pointOfInterestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForACityAsync(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
