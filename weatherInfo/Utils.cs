namespace weatherInfo;

public class Utils
{
    public static int createMenu()
    {
        bool isSelected = false;
        int selectedOption = 0;
        string prefix;
        string[] options = { "> List 3 day weather info for Turkey (Istanbul, Izmir, Ankara)", "> Show specific weather" };
        
        do
        {
            Console.SetCursorPosition(0, 8);
            
            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
    
                if (i == selectedOption)
                {
                    prefix = ">";
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                Console.WriteLine($"{currentOption}");
                Console.ResetColor();
            }
            
            Console.WriteLine("\n> (esc to exit)");
            var pressedKey = Console.ReadKey();
                
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                selectedOption--;
                    
                if (selectedOption == -1)
                {
                    selectedOption = options.Length - 1;
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                selectedOption++;
                    
                if (selectedOption == options.Length)
                {
                    selectedOption = 0;
                }
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.WriteLine(selectedOption);
                isSelected = true;
            }
            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            
        } while (!isSelected);
        
        return selectedOption;
    }
    
    public static void writeLogo()
    {
        string logo = @"
                             _   _             _____        __       
                            | | | |           |_   _|      / _|      
         __      _____  __ _| |_| |__   ___ _ __| |  _ __ | |_ ___   
         \ \ /\ / / _ \/ _` | __| '_ \ / _ \ '__| | | '_ \|  _/ _ \  
          \ V  V /  __/ (_| | |_| | | |  __/ | _| |_| | | | || (_) | 
           \_/\_/ \___|\__,_|\__|_| |_|\___|_||_____|_| |_|_| \___/
            ";

        Console.WriteLine(logo);
    }
    
    public static WeatherInfo formatData(WeatherInfo weatherData)
    {
        WeatherInfo formattedData = weatherData;
    
        if (formattedData.temperature.Contains("+"))
        {
            formattedData.temperature = formattedData.temperature.Replace("+", "");
        }
        else
        {
            formattedData.temperature = weatherData.temperature;
        }
    
        foreach (var forecast in formattedData.forecast)
        {
            if (forecast.temperature.Contains("+"))
            {
                forecast.temperature = forecast.temperature.Replace("+", "");
            }
        }

        return formattedData;
    }
    
    public static string getIcon(string key)
    {
        string sun =
            "\n      \\ | /\n" +
            "     - ( ) -\n" +
            "      / | \\\n";
    
        string cloud =
            "\n        .--.\n" +
            "     .-(    ).\n" +
            "    (___._(___)\n";
    
        string snow =
            "     * * * * *\n" +
            "    * * * *\n";
    
        string rain =
            "     ‚’‚’‚’‚’\n";
    
        string thunderstormRain =
            "    ‚’‚’\u26a1‚’‚’\n";
    
        string unknown =
            "\n  ___\n" +
            " |__ \\\n" +
            "    ) |\n" +
            "   / /\n" +
            "  |_|\n" +
            "  (_)\n";
    
        Dictionary<string, string> descSymbols = new Dictionary<string, string>()
        {
            //https://openweathermap.org/weather-conditions
            {"Clear", sun},
            {"Sunny", sun},
            {"Partly cloudy", cloud},
            {"Light rain", cloud + rain},
            {"Light rain, mist", cloud + rain},
            {"Light rain shower", cloud + rain},
            {"Light freezing drizzle", cloud + snow},
            {"Rain with thunderstorm", cloud + thunderstormRain},
            {"Unknown", unknown}
        };
    
        if (string.IsNullOrEmpty(key) || !descSymbols.Keys.Contains(key))
        {
            return descSymbols["Unknown"];
        }
        else
        {
            return descSymbols[key];   
        }
    }
}