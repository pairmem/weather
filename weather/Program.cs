using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace HttpClientExtensionMethods
{
      public class City
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        [JsonPropertyName("current_weather")]
        public CurrentWeather? CurrentWeather { get; set; }
        //public string? Username { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("windspeed")]
        public double Windspeed { get; set; }

        [JsonPropertyName("winddirection")]
        public double Winddirection { get; set; }

        [JsonPropertyName("weathercode")]
        public int Weathercode { get; set; }

        [JsonPropertyName("time")]
        public string? Time { get; set; }
    }

    public class Program
    {
        public static async Task Main()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current_weather=true")
            };

            // Get Json Weather information.
            City? city = await client.GetFromJsonAsync<City>("");
            


            Console.WriteLine($"Latitude: {city?.Latitude}");
            Console.WriteLine($"Longitude: {city?.Longitude}");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Console.WriteLine($"Temperature: {city?.CurrentWeather.Temperature}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Console.WriteLine($"WindSpeed: {city?.CurrentWeather.Windspeed}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.


        }
    }
}
