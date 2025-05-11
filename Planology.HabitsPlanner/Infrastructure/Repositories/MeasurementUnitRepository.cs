using Domain.Enums;
using Domain.IRepository;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class MeasurementUnitRepository : IMeasurementUnitRepository
    {
        private readonly IMongoCollection<MeasurementUnit> _collection;

        public MeasurementUnitRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<MeasurementUnit>("MeasurementUnits");
        }

        public async Task<List<MeasurementUnit>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<MeasurementUnit?> GetByIdAsync(string id)
        {
            return await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MeasurementUnit>> GetByCategoryAsync(UnitCategory category)
        {
            return await _collection.Find(u => u.Category == category).ToListAsync();
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _collection.Find(u => u.Id == id).AnyAsync();
        }

        public async Task CreateAsync(MeasurementUnit unit)
        {
            await _collection.InsertOneAsync(unit);
        }
    }
}
