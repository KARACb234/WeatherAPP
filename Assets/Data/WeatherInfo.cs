using JsonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonData
{
    public class WeatherInfo
    {
        public LocationData location;
        public CurrentData current;
        public ForecastData forecast;
    }
}
