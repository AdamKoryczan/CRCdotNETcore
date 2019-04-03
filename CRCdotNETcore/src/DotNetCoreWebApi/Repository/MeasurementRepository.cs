using DotNetCoreWebApi.DBContexts;
using DotNetCoreWebApi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Repository
{
    public class MeasurementRepository : IMeasurementRepository<Measurement>
    {
        private readonly MeasurementContext _measurementContext;

        public MeasurementRepository(MeasurementContext context)
        {
            _measurementContext = context;
        }

        public async Task Add(Measurement entity)
        {
            await _measurementContext.Measurements.AddAsync(entity);
            await _measurementContext.SaveChangesAsync();
        }

        public async Task Delete(Measurement measurement)
        {
            _measurementContext.Measurements.Remove(measurement);
            await _measurementContext.SaveChangesAsync();
        }

        public async Task<Measurement> Get(long id)
        {
            return await _measurementContext.Measurements.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Measurement>> GetAll()
        {
            return await _measurementContext.Measurements.ToListAsync();
        }

        public async Task Update(Measurement measurement, Measurement entity)
        {
            measurement.Name = entity.Name;
            measurement.Value = entity.Value;
            measurement.CreatedAt = entity.CreatedAt;
            measurement.CreatedBy = measurement.CreatedBy;

            await _measurementContext.SaveChangesAsync();
        }
    }
}
