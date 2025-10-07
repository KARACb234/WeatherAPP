using JsonData;

namespace Assets.Scripts
{
    public class DayButonInfo
    {
        private readonly int _butonIndex;
        public int GetButonIndex => _butonIndex;
        private readonly ForecastDayData _forecastForecastDayData;
        public ForecastDayData GetForecastForecastDayData => _forecastForecastDayData;

        public DayButonInfo( int butonIndex, ForecastDayData  forecastDayData)
        {
            _butonIndex = butonIndex;
            _forecastForecastDayData = forecastDayData;
        }
    }
}
