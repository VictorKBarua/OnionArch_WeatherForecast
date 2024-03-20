using Microsoft.EntityFrameworkCore;
using WeatherForecast.Models;

namespace WeatherForecast.Dal.Repositories
{
    public class ForecastRepositories<T> : IForecastRepositories<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;
        public ForecastRepositories(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                return _entities.AsEnumerable();
            }
            catch
            {
                throw new ArgumentNullException("Weather details not found.");
            }
        }
       
        public long Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity is null.");
            try
            {
                _entities.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"Error occured while storing entity with error {ex.Message}.");
            }
        }
    }
}

