using System.Diagnostics;
using weatherInfo;

Utils.writeLogo();
int selectedOption = Utils.createMenu();

if (selectedOption == 0)
{
    Console.Clear();
    Utils.writeLogo();
    DateTime date = DateTime.Now;
    
    (WeatherInfo istanbulWeather, int istanbulResponseStatus) = await ApiHandler.getDataFor("Istanbul");
    WeatherInfo istanbulFormattedData = Utils.formatData(istanbulWeather);
    var istanbulIcon = Utils.getIcon(istanbulWeather.description);
    Console.SetCursorPosition(0, 8);
    Console.Write($"> Showing weather information for: Istanbul");
    Console.SetCursorPosition(0, 9);
    Console.WriteLine(istanbulIcon);
    Console.SetCursorPosition(20, 10);
    Console.WriteLine($"{istanbulFormattedData.description}");
    Console.SetCursorPosition(20, 11);
    Console.WriteLine($"{istanbulFormattedData.temperature}");
    Console.SetCursorPosition(20, 12);
    Console.WriteLine($"{istanbulFormattedData.wind}");
    Console.WriteLine("\n");
    
    foreach (var forecast in istanbulWeather.forecast)
    {
        date = date.AddDays(1);
        Console.WriteLine($"- {date.ToString("d MMM")}, {forecast.temperature}, {forecast.wind}");
    }
    
    (WeatherInfo ankaraWeather, int ankaraResponseStatus) = await ApiHandler.getDataFor("Ankara");
    WeatherInfo ankaraFormattedData = Utils.formatData(ankaraWeather);
    var ankaraIcon = Utils.getIcon(ankaraWeather.description);
    Console.SetCursorPosition(0, 20);
    Console.Write($"> Showing weather information for: Ankara");
    Console.SetCursorPosition(0, 21);
    Console.WriteLine(ankaraIcon);
    Console.SetCursorPosition(20, 19);
    Console.WriteLine($"{ankaraFormattedData.description}");
    Console.SetCursorPosition(20, 20);
    Console.WriteLine($"{ankaraFormattedData.temperature}");
    Console.SetCursorPosition(20, 21);
    Console.WriteLine($"{ankaraFormattedData.wind}");
    Console.WriteLine("\n");
    
    foreach (var forecast in ankaraWeather.forecast)
    {
        date = date.AddDays(1);
        Console.WriteLine($"- {date.ToString("d MMM")}, {forecast.temperature}, {forecast.wind}");
    }
    
    (WeatherInfo izmirWeather, int izmirResponseStatus) = await ApiHandler.getDataFor("Izmir");
    WeatherInfo izmirFormattedData = Utils.formatData(izmirWeather);
    var izmirIcon = Utils.getIcon(izmirWeather.description);
    Console.WriteLine("\n");
    Console.Write($"> Showing weather information for: Izmir");
    Console.WriteLine("\n" + izmirIcon);
    Console.SetCursorPosition(20, 19);
    Console.WriteLine($"{izmirFormattedData.description}");
    Console.SetCursorPosition(20, 20);
    Console.WriteLine($"{izmirFormattedData.temperature}");
    Console.SetCursorPosition(20, 21);
    Console.WriteLine($"{izmirFormattedData.wind}");
    Console.WriteLine("\n");
    
    foreach (var forecast in izmirWeather.forecast)
    {
        date = date.AddDays(1);
        Console.WriteLine($"- {date.ToString("d MMM")}, {forecast.temperature}, {forecast.wind}");
    }
}
else if (selectedOption == 1)
{
    Console.Clear();
    Utils.writeLogo();
    
    var inputCity = getCity();
    (WeatherInfo weatherData, int responseStatus) = await ApiHandler.getDataFor(inputCity);
    WeatherInfo formattedData = Utils.formatData(weatherData);
    var icon = Utils.getIcon(weatherData.description);

    if (responseStatus == 404)
    {
        Console.WriteLine($"Couldn't fetch weather information. But this is not your fault.");
    } else if (responseStatus == null || responseStatus == 000)
    {
        Console.SetCursorPosition(0, 8);
        Console.Write($"> Showing weather information for: {inputCity}");
        Console.SetCursorPosition(0, 9);
        Console.WriteLine(icon);
        Console.SetCursorPosition(20, 10);
        Console.WriteLine($"{formattedData.description}");
        Console.SetCursorPosition(20, 11);
        Console.WriteLine($"{formattedData.temperature}");
        Console.SetCursorPosition(20, 12);
        Console.WriteLine($"{formattedData.wind}");
        Console.WriteLine("\n");
    
        DateTime date = DateTime.Now;
    
        foreach (var forecast in weatherData.forecast)
        {
            date = date.AddDays(1);
            Console.WriteLine($"- {date.ToString("d MMM")}, {forecast.temperature}, {forecast.wind}");
        }
    }
}

static string getCity()
{
    // check if null or blank space
    Console.Write("> Enter City: ");
    var input = Console.ReadLine();

    return input;
}