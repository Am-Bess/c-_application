using System.Text.Json;
using System.Xml.Serialization;

namespace JsonToXml
{
    public class Weather
    {
        public DateTime Time { get; set; }
        public double Temp { get; set; }
        public int WeatherCode { get; set; }
        public double WindSpeed { get; set; }
        public int WindDirection { get; set; }
    }

    public class WeatherFull
    {
        public Weather? Current { get; set; }
        public List<Weather>? History { get; set; }
    }
    internal class Program
    {
        static void JsonToXml(string jsonStr)
        {
            var weatherFull = JsonSerializer.Deserialize<WeatherFull>(jsonStr);
            var serializer = new XmlSerializer(typeof(WeatherFull));

            serializer.Serialize(Console.Out, weatherFull);
        }

        static void Main(string[] args)
        {
            var json = """
        {
        "Current": {
            "Time": "2024-10-10T09:07:06",
            "Temperature": 20,
            "WeatherCode": 2,
            "WindSpeed": 3.1,
            "WindDirection": 7
        },
        "History": [
            {
            "Time": "2024-10-15T21:11:50",
            "Temperature": 25,
            "WeatherCode": 4,
            "WindSpeed": 3.4,
            "WindDirection": 2
            },
            {
            "Time": "2024-10-20T03:06:33",
            "Temperature": 18,
            "WeatherCode": 4,
            "WindSpeed": 7.4,
            "WindDirection": 3
            },
            {
            "Time": "2024-10-25T16:36:00",
            "Temperature": 14,
            "WeatherCode": 8,
            "WindSpeed": 5.2,
            "WindDirection": 6
            }
        ]
        }
        """;

            JsonToXml(json);
        }
    }
}

