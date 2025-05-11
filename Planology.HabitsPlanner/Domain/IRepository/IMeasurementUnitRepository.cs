using Domain.Enums;

namespace Domain.IRepository
{
    public interface IMeasurementUnitRepository
    {
        Task<List<MeasurementUnit>> GetAllAsync();
        Task<MeasurementUnit?> GetByIdAsync(string id);
        Task<List<MeasurementUnit>> GetByCategoryAsync(UnitCategory category);
        Task<bool> ExistsAsync(string id);
        Task CreateAsync(MeasurementUnit unit);
    }

}
