using System.Text.Json.Serialization;

namespace FuelPrices.Core.Stations;

public class Station
{
  public string Id { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Brand { get; set; } = string.Empty;
  public string Street { get; set; } = string.Empty;
  public string HouseNumber { get; set; } = string.Empty;
  public int PostCode { get; set; }
  public string Place { get; set; } = string.Empty;
  public double Lat { get; set; }
  public double Lng { get; set; }
  public double Dist { get; set; }
  public bool IsOpen { get; set; }

  [JsonConverter(typeof(PriceJsonConverter))]
  public double? Diesel { get; set; }

  [JsonConverter(typeof(PriceJsonConverter))]
  public double? E5 { get; set; }

  [JsonConverter(typeof(PriceJsonConverter))]
  public double? E10 { get; set; }
}
