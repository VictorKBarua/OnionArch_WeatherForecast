namespace WeatherForecast.UtilitiesService
{
    public static class ServiceConstant
    {
        #region(Error Messages)
        public const string ErrMsgNullEntity = "Entity is null.";
        public const string ErrMsgDateRange = "Date cannot be in the past.";
        public const string ErrMsgTemperatureRange = "Temperature must be between (-)60 and (+)60 degrees.";
        #endregion

        #region(Constants Value)
        public const double constTemperatureMin = -60;
        public const double constTemperatureMax = 60;
        public const int constTakeValue = 7;
        #endregion
    }
}
