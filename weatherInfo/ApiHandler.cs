using System;
using Newtonsoft.Json;

namespace weatherInfo
{
	public class ApiHandler
	{
		private static string apiUrls { get; set; }
		
		public static async Task<WeatherInfo> requestTo(string apiUrl)
		{
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();
					WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(responseData);
					return weatherInfo;
				}
				else
				{
					return null;
				}
			}
			catch (HttpRequestException exc)
			{
				Console.WriteLine(exc);
				return null;
			}
		}
		
		public static async Task<WeatherInfo> getDataFor(string city)
		{
			string[] cities = { "istanbul", "izmir", "ankara" };

			if (cities.Contains(city.ToLower()))
			{
				apiUrls = $"https://goweather.herokuapp.com/weather/{city}";
				WeatherInfo weatherInfo = await requestTo(apiUrls);
				return weatherInfo;
			}
			else
			{
				Console.WriteLine($"Couldn't find data for {city}");
				return null;
			}
		}
	}
}

