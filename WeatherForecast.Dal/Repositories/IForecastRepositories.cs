using WeatherForecast.Models;

namespace WeatherForecast.Dal.Repositories
{
    public interface IForecastRepositories<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        long Insert(T entity);
    }
}
