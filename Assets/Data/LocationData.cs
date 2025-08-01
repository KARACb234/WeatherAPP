using Newtonsoft.Json;
using System;

namespace JsonData
{
    public class LocationData
    {
        public string name;
        public string region;
        public string country;
        public decimal lat;
        public decimal lon;
        [JsonProperty("tz_id")]
        public string tzId;
        [JsonProperty("localtime_epoch")]
        public int localtimeEpoch;
        public DateTime localtime;
    }
}
