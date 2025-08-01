using Newtonsoft.Json;
using System;

namespace JsonData
{ 
    public class CurrentData
    {
        [JsonProperty("last_updated_epoch")]
        public int lastUpdatedEpoch;
        [JsonProperty("last_updated")]
        public DateTime lastUpdated;
        [JsonProperty("temp_c")]
        public decimal tempC;
        [JsonProperty("temp_f")]
        public decimal tempF;
        [JsonProperty("is_day")]
        public int isDay;
        public ConditionData condition;
        public decimal wind_mph;
        public decimal wind_kph;
        public int wind_degree;
        public string wind_dir;
        public float pressure_mb;
        public decimal pressure_in;
        public decimal precip_mm;
        public decimal precip_in;
        public int humidity;
        public int cloud;
        public decimal feelslike_c;
        public decimal feelslike_f;
        public decimal windchill_c;
        public decimal windchill_f;
        public decimal heatindex_c;
        public decimal heatindex_f;
        public decimal dewpoint_c;
        public decimal dewpoint_f;
        public decimal vis_km;
        public decimal vis_miles;
        public decimal uv;
        public decimal gust_mph;
        public decimal gust_kph;

    }
}
