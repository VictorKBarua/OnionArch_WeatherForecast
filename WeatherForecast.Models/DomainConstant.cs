namespace WeatherForecast.Models
{
    public static class DomainConstant
    {
        #region(Error Messages)
        public const string ErrMsgDateRange = "Forecast cannot be of past date.";
        public const string ErrMsgTemperatureRange = "Temperature must be between (-)60 and (+)60 degrees.";
        #endregion

        #region(Constants Value)
        public const string constStrFreezing = "Freezing";
        public const string constStrBracing = "Bracing";
        public const string constStrChilly = "Chilly";
        public const string constStrCool = "Cool";
        public const string constStrMild = "Mild";
        public const string constStrWarm = "Warm";
        public const string constStrBalmy = "Balmy";
        public const string constStrHot = "Hot";
        public const string constStrSweltering = "Sweltering";
        public const string constStrScorching = "Scorching";
        #endregion
    }
}
