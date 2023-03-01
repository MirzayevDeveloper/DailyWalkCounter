using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IDistanceService
    {
        Task AddDistanceAsync(IDistance distance);
        Task<bool> DeleteDistanceByIdAsync(Guid distanceId);
        Task<bool> UpdateDistanceAsync(IDistance distance);
        IDistance GetDistanceById(Guid distanceId);
        IList<IDistance> GetAllDistances();
    }
}
