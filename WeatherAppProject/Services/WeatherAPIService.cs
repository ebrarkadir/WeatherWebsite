using Accuweather;
using Newtonsoft.Json.Linq;
using WeatherAppProject.Models;

namespace WeatherAppProject.Services
{
    public static class WeatherAPIService
    {
        public static async Task<Weather> GetWeatherAsync(string city)
        {
            var apiKey = "967c1f8db6c2eed60d2f940b9ac7e33d";
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang=en&appid={apiKey}";

            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(jsonString);
            var temperature = data["main"]["temp"];
            var description = data["weather"][0]["description"];
            var main = data["weather"][0]["main"];
            var icon = data["weather"][0]["icon"];


            var weather = new Weather();

            weather.Temperature = temperature.ToString();
            weather.Description = description.ToString();
            weather.Main = main.ToString();
            weather.Icon = icon.ToString() + ".png";
            weather.City = city.ToString();

            return weather;
        }


    }
}
