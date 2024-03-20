namespace WeatherForecast.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
    }
}
