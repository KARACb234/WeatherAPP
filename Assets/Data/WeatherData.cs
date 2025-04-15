using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonData
{
    public class WeatherData
    {
        public float latitude;
        public float longitude;
        [JsonProperty("generationtime_ms")]
        public float generationTimeMS;
        [JsonProperty("utc_offset_seconds")]
        public int UTCOffsetSeconds;
        public string elevation;
        public string timezone;
        [JsonProperty("timezone_abbreviation")]
        public string timezoneAbbreviation;
        public HourlyUnitsData hourly_units;
        public HourlyData hourly;

    }
}