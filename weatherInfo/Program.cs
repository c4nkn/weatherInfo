using weatherInfo;

Console.Write("Enter city: ");
string city = Console.ReadLine();

var weatherData = await ApiHandler.getDataFor(city);
Console.WriteLine($"Showing weather information for: {city}");
Console.WriteLine($"Description: {weatherData.description}\nTemperature: {weatherData.temperature}\nWind: {weatherData.wind}");

foreach (var forecast in weatherData.forecast)
{
    Console.WriteLine($">> Day: {forecast.day}, Temperature: {forecast.temperature}, Wind: {forecast.wind}");
}