using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherForecast.Models
{
    public class WeatherMap
    {
        public WeatherMap(EntityTypeBuilder<WeatherDailyForecast> EntityBuilder)
        {
            EntityBuilder.HasKey(x => x.Id);
        }
        //public WeatherMap(EntityTypeBuilder<WeatherDescription> EntityBuilder)
        //{
        //    EntityBuilder.HasKey(x => x.Id);
        //}
    }
}
