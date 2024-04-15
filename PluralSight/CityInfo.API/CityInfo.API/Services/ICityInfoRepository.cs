using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);

        Task<bool> CityExistsAsync(int cityId);

        void DeletePointOfInterest(PointOfInterest pointOfInterest);

        Task<IEnumerable<City>> GetCitiesAsync();

        Task<IEnumerable<City>> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);

        Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);

        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
        
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);

        Task<bool> SaveChangesAsync();
    }
}
