using System;

namespace weatherInfo
{
	public class WeatherInfo
	{
		// temperature(string), wind(string), description(string), forecast(class)
		public string temperature { get; set; }
		public string wind { get; set; }
		public string description { get; set; }
		public Forecast[] forecast { get; set; }
	}
}

