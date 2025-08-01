using System;

namespace JsonData
{
    public class ForecastDayData
    {
        public DateTime date;
        public int date_epoch;
        public DayData day;
        public AstroData astro;
        public HourData[] hour;
    }
}
