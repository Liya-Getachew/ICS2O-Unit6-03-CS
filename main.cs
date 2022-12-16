using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=45.4211435&lon=-75.6900574&appid=fe1d80e1e103cff8c6afd190cad23fa5");
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
        JsonNode forecastNode = JsonNode.Parse(response)!;
        // Console.WriteLine(forecastNode);
        JsonNode weatherNode = forecastNode!["weather"][0]!;
        // Console.WriteLine(weatherNode);
        JsonNode main = weatherNode!["main"]!;
        // Console.WriteLine(mainNode);
        Console.WriteLine(main);
        Console.WriteLine("");
        // Console.WriteLine(forecastNode);
        JsonNode main1Node = forecastNode!["main"]!;
        // Console.WriteLine(main1Node);
        JsonNode temp = main1Node!["temp"]!;
        JsonNode feel = main1Node!["feels_like"]!;
        Console.WriteLine(temp + " K, feels like " + feel + " K");
        JsonNode humidity = main1Node!["humidity"]!;
        Console.WriteLine("Humidity: " + humidity + "%");
    }
}