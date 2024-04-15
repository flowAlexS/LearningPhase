using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<City?> GetCityAsync(int cityId);

        Task<PointOfInterest?> GetPointOfInterestForACityAsync(int cityId, int pointOfInterestId);
        
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForACityAsync(int cityId);
    }
}
