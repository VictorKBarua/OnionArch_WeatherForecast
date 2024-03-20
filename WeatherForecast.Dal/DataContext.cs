using Microsoft.EntityFrameworkCore;
using WeatherForecast.Models;

namespace WeatherForecast.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new WeatherMap(modelBuilder.Entity<WeatherDailyForecast>());

            //new WeatherMap(modelBuilder.Entity<WeatherDescription>());
            //modelBuilder.Entity<WeatherDescription>().HasData(
            //    new WeatherDescription
            //    {

            //    }
            //    );

        }
    }
}
